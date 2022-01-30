import { FilterCollectionsTogglePipe } from './private-or-public-toggle.pipe';

describe('filterCollectionsTogglePipe', () => {
  it('create an instance', () => {
    const pipe = new FilterCollectionsTogglePipe();
    expect(pipe).toBeTruthy();
  });
});
