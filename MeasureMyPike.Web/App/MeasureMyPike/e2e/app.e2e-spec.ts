import { MeasureMyPikePage } from './app.po';

describe('measure-my-pike App', () => {
  let page: MeasureMyPikePage;

  beforeEach(() => {
    page = new MeasureMyPikePage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
