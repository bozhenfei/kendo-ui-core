#!/usr/bin/env node

// Imports ====================================================================
var fs = require("fs"),
    sys = require("sys"),
    path = require("path"),
    spawn = require('child_process').spawn,
    kendoBuild = require("./kendo-build"),
    processFiles = kendoBuild.processFilesRecursive,
    mkdir = kendoBuild.mkdir;

// Configuration ==============================================================
var SUITES = ["web", "dataviz"],
    EXAMPLES_ROOT = path.join("demos", "examples"),
    VIEWS_ROOT = path.join("demos", "mvc", "Views"),
    CONTENT_ROOT = path.join("demos", "mvc", "content");

// Implementation ==============================================================
SUITES.forEach(function(suite) {
    var suiteRoot = path.join(EXAMPLES_ROOT, suite);

    processFiles(
        suiteRoot,
        /.html$/,
        function (fileName) {
            var outputFile = fileName
                .replace(EXAMPLES_ROOT, VIEWS_ROOT)
                .replace(".html", ".cshtml");

            try {
                mkdir(path.dirname(outputFile));
                kendoBuild.copyFileSync(fileName, outputFile);

                var content = kendoBuild.readText(outputFile);
                content = content
                    .replace(/(.|\n)+<body>((.|\n)+)<\/body>(.|\n)+/m, "$2")
                    .replace(/<div class="description">((.|\n)+?)<\/div>/m, "")
                    .replace("../content", "../../content/" + suite)
                    .replace(/\s*<!--\s*\w+\s*-->\s*$/gm, "");

                kendoBuild.writeText(outputFile, content);
            } catch (e) {
                console.log("Trouble converting ", fileName, "to ", outputFile);
            }
        }
    );

    processFiles(
        suiteRoot,
        /\.(?!html$)/,
        function (fileName) {
            var outputFile = fileName
                    .replace("content/", "")
                    .replace(EXAMPLES_ROOT, CONTENT_ROOT);

            try {
                mkdir(path.dirname(outputFile));
                kendoBuild.copyFileSync(fileName, outputFile);
            } catch (e) {
                console.log("Trouble copying ", fileName, "to ", outputFile);
            }
        }
    );
});
