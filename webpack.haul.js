var path = require("path");
var webpack = require("webpack");
var fableUtils = require("fable-utils");

function resolvePath(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
  presets: [
    ["react-native"]
  ],
});

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = ({ platform }, { module, resolve }) => ({
  devtool: "eval-source-map",
  entry: resolvePath('./docs/native/Docs.Native.fsproj'),
  module: {
    ...module,
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      },
      ...module.rules
    ]
  },
  resolve: {
    ...resolve,
    modules: [
      resolvePath("./node_modules/"),
    ]
  }
});