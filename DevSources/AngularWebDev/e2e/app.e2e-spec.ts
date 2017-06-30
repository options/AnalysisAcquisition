import { MyAngFEPage } from './app.po';

describe('my-ang-fe App', () => {
  let page: MyAngFEPage;

  beforeEach(() => {
    page = new MyAngFEPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
