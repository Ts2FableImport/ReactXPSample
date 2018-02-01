import * as reactxp from "reactxp";
import { RX } from "./Fable.Helps.ReactXP";
export function init() {
  (() => {
    const objectArg = reactxp.UserInterface;
    return function (arg00) {
      objectArg.setMainView(arg00);
    };
  })()(RX.Hello);
}
init();