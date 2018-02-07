const path = require("path");
const fableUtils = require("fable-utils");

function resolve(filePath) {
  return path.resolve(__dirname, filePath)
}



module.exports = {
  entry: resolve("src/native/ReactXPSample.Native.fsproj"),
  outDir: "public",
  babel: fableUtils.resolveBabelOptions({
    plugins: ["transform-es2015-modules-commonjs"],
    sourceMaps: true
  }),
  fable: { define: ["DEBUG"] }
};