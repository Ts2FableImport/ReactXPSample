const path = require("path");
const fableUtils = require("fable-utils");

function resolve(filePath) {
  return path.resolve(__dirname, filePath)
}



module.exports = {
  entry: resolve("../docs/native/Docs.Native.fsproj"),
  outDir: "docs/native/bin",
  babel: fableUtils.resolveBabelOptions({
    plugins: ["transform-es2015-modules-commonjs"],
    sourceMaps: true
  }),
  fable: { define: ["DEBUG"] }
};