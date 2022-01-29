import { PrivateOrPublicTogglePipe } from './private-or-public-toggle.pipe';

describe('PrivateOrPublicTogglePipe', () => {
  it('create an instance', () => {
    const pipe = new PrivateOrPublicTogglePipe();
    expect(pipe).toBeTruthy();
  });
});
