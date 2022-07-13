const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;

describe('E2E tests', async function() {
    this.timeout(5000);
    before(async() => { browser = await chromium.launch(); });
    after(async() => { await browser.close(); });
    beforeEach(async() => { page = await browser.newPage(); });
    afterEach(async() => { await page.close(); });

    it('loads page', async() => {
        await page.goto('http://localhost:5501');
        // await page.screenshot({ path: 'site.png' });

        const content = await page.textContent('#main');

        expect(content).to.contain('Scalable Vector Graphics');
        expect(content).to.contain('Open standard');
        expect(content).to.contain('Unix');
        expect(content).to.contain('ALGOL');

    })

    //await page.waitForTimeout(200); - not recommended solution for testing when app is not local hosted;

    //await page.waitForSelector('.accordion'); - recommended solution for testing when app is not local hosted;

    it('shows accordion visible when click', async() => {
        await page.goto('http://localhost:5501');
        // await page.screenshot({ path: 'site.png' });


        await page.click('text=More');
        await page.waitForSelector('.accordion p')

        const visible = await page.isVisible('.accordion p');

        expect(visible).to.be.true;

    })

    it('hides accordion visibility when click "Less"', async() => {
        await page.goto('http://localhost:5501');
        // await page.screenshot({ path: 'site.png' });


        await page.click('text=More');
        await page.waitForSelector('.accordion p')
        let visible = await page.isVisible('.accordion p');
        expect(visible).to.be.true;

        await page.click('text=Less');
        visible = await page.isVisible('.accordion p');
        expect(visible).to.be.false;

    })



})