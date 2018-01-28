"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.init = init;

var _reactxp = require("reactxp");

var reactxp = _interopRequireWildcard(_reactxp);

var _react = require("react");

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }

function init() {
  reactxp.UserInterface.setMainView((0, _react.createElement)("div", {}, "Hello"));
}

init();