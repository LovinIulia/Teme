import { AddPipe } from './addHyphen.pipe';

describe('AddPipe', () => {
  it('create an instance', () => {
    const pipe = new AddPipe();
    expect(pipe).toBeTruthy();
  });
});
