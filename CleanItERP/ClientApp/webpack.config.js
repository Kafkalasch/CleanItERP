// spell-checker: ignore devtool

const path = require('path');
const webpack = require('webpack');
const TsconfigPathsPlugin = require('tsconfig-paths-webpack-plugin');
const ForkTsCheckerNotifierWebpackPlugin = require('fork-ts-checker-notifier-webpack-plugin');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
const WebpackNotifierPlugin = require('webpack-notifier');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin')

const buildFolder = "build";

module.exports = {
    entry: './src/index.tsx',
    mode: "development",
    devtool: "inline-source-map",
    devServer: {
        contentBase: path.join("./", buildFolder),
        hot: true
    },
    module: {
        rules: [

            {
                test: /\.(png|svg|jpg|gif|woff|woff2|eot|ttf|otf|dae|csv)$/,
                use: [
                    "file-loader"
                ]
            },
            {
                test: /\.tsx?$/,
                loader: 'ts-loader',
                options: {
                    // disable type checker - we will use it in fork plugin
                    transpileOnly: true
                }

            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            {
                test: /\.scss$/,
                use: [
                    'style-loader',
                    "css-loader",
                    'sass-loader?sourceMap'
                ]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new WebpackNotifierPlugin({ skipFirstNotification: true }),
        new ForkTsCheckerWebpackPlugin(),
        new ForkTsCheckerNotifierWebpackPlugin({ skipSuccessful: true }),
        new webpack.HotModuleReplacementPlugin(),
        new HtmlWebpackPlugin({
            title: "Clean It!",
            favicon: "./assets/logo.png",
            template: "index.hbs"
        })
    ],
    resolve: {
        extensions: ['.ts', '.tsx', '.js'],
        plugins: [new TsconfigPathsPlugin()]
    },
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, buildFolder)
    }
};