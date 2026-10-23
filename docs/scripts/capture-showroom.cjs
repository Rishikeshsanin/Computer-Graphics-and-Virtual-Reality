// Genuine browser captures. Mobile is Chromium emulation, NOT hardware testing.
const { chromium } = require('../../.ci_tools/node_modules/playwright');
const fs = require('node:fs');
const path = require('node:path');
const output = path.resolve(__dirname, '..', 'screenshots');
fs.mkdirSync(output, { recursive: true });
const url = 'http://127.0.0.1:8000/';
const captures = [];
const errors = [];
async function ready(page, label) {
  const response = await page.goto(url, { waitUntil: 'domcontentloaded', timeout: 60000 });
  if (!response.ok()) throw Error(label + ': HTTP ' + response.status());
  await page.waitForFunction(() => {
    const load = document.getElementById('loading');
    const err = document.getElementById('error-message');
    const c = document.getElementById('showroom');
    return load && load.hidden && err && err.hidden && c && c.width > 300 && c.height > 200;
  }, null, { timeout: 60000 });
  await page.waitForTimeout(1200);
}
async function shot(page, file, caption) {
  await page.waitForTimeout(500);
  await page.screenshot({ path: path.join(output, file), fullPage: true, animations: 'disabled' });
  if (fs.statSync(path.join(output, file)).size < 12000) throw Error('Invalid screenshot size: ' + file);
  captures.push({ file, caption });
}
async function main() {
  const browser = await chromium.launch({
    headless: true,
    args: ['--no-sandbox','--enable-webgl','--use-gl=angle','--use-angle=swiftshader','--disable-dev-shm-usage']
  });
  try {
    const desktop = await browser.newContext({ viewport: { width: 1440, height: 900 }, deviceScaleFactor: 1 });
    const page = await desktop.newPage();
    page.on('pageerror', e => errors.push('desktop: ' + e.message));
    await ready(page, 'desktop');
    await shot(page, 'desktop_room.png', 'Desktop Chromium: furniture studio overview');
    await page.locator('[data-focus="sofa"]').click();
    await page.locator('#tab-material').click();
    await shot(page, 'desktop_materials.png', 'Desktop Chromium: sofa materials');
    await page.locator('#tab-mapping').click();
    await page.locator('#mapping-reset').click();
    const coords = await page.locator('#mapped-result').innerText();
    if (!coords.includes('657.5') || !coords.includes('708.0')) throw Error('Mapping mismatch: ' + coords);
    await shot(page, 'desktop_mapping.png', 'Desktop Chromium: viewport mapping (657.5, 708.0)');
    await page.locator('#tab-light').click();
    await page.locator('[data-light="ambient"]').click();
    await shot(page, 'desktop_ambient.png', 'Desktop Chromium: ambient-only lighting');
    await page.locator('[data-light="specular"]').click();
    await shot(page, 'desktop_phong.png', 'Desktop Chromium: full Phong lighting');
    const mobile = await browser.newContext({
      viewport: { width: 390, height: 844 }, screen: { width: 390, height: 844 },
      deviceScaleFactor: 1, isMobile: true, hasTouch: true
    });
    const phone = await mobile.newPage();
    phone.on('pageerror', e => errors.push('mobile emulation: ' + e.message));
    await ready(phone, 'mobile');
    const overflow = await phone.evaluate(() => document.documentElement.scrollWidth - innerWidth);
    if (overflow > 5) throw Error('Mobile horizontal overflow ' + overflow + 'px');
    await shot(phone, 'mobile_emulated_room.png', '390px emulated mobile Chromium: showroom');
    await phone.locator('#tab-mapping').click();
    await shot(phone, 'mobile_emulated_mapping.png', '390px emulated mobile Chromium: mapping');
    await mobile.close(); await desktop.close();
  } finally { await browser.close(); }
  if (errors.length) throw Error('JavaScript errors: ' + errors.join('; '));
  const md = [
    '# Furniture Studio — genuine browser screenshots',
    '',
    '[← Repository](../README.md) · [Live app](https://cgvr-furniture-studio.vercel.app/) · [Case study](../CASE%20STUDY%20CIE3/README.md)',
    '',
    'These are screenshots of the **actual running web application** captured with headless Chromium in GitHub Actions. They are **not AI images**. Mobile images use a **390px emulated browser viewport**, not a physical iPhone/Android device. They do not establish hardware AR or Unity Play-mode validation.',
    '',
    '| Test view | Captured screenshot |',
    '|---|---|'
  ];
  for (const item of captures) {
    md.push('| **' + item.caption + '** | [![' + item.caption + '](screenshots/' + item.file + ')](screenshots/' + item.file + ') |');
  }
  md.push('', '**Validation:** scene loading, nonzero WebGL canvas dimensions, logical-to-pixel mapping and mobile horizontal overflow checked. These are Chromium CI checks, not physical-device testing.', '');
  fs.writeFileSync(path.resolve(__dirname, '..', 'BROWSER_SCREENSHOTS.md'), md.join('\n'));
  console.log('Captured ' + captures.length + ' application screenshots.');
}
main().catch(e => { console.error(e); process.exit(1); });
