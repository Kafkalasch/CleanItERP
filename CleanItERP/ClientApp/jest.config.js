const {pathsToModuleNameMapper} = require("ts-jest/utils");
const {compilerOptions} = require("./tsconfig");

const tsPathsMapper = pathsToModuleNameMapper(compilerOptions.paths, {prefix: "<rootDir>/"});

module.exports = {
    preset: "ts-jest",
    testEnvironment: "node",
    moduleNameMapper: {
        ...tsPathsMapper,
        "\\.(jpg|jpeg|png|gif|eot|otf|svg|ttf|woff|woff2)$": "<rootDir>/src/__mocks__/fileMock.js",
        "\\.(css|scss)$": "<rootDir>/src/__mocks__/styleMock.js"
    }
}