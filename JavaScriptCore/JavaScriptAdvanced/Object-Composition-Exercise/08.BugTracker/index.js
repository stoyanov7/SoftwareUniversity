function solve() {
     let id = 0;
     let bugReports = [];

     function refreshReports(reports) {
          let contentDiv = document.querySelector("#content");
          contentDiv.innerHTML = "";

          let tempReports = reports.slice(0);

          Array.from(tempReports).forEach((rep) => {
               let reportDiv = generateReportDiv(rep);
               contentDiv.appendChild(reportDiv);
          });
     }

     function generateReportDiv(newReport) {
          let reportDiv = document.createElement("div");
          reportDiv.classList.add("report");
          reportDiv.id = "report_" + newReport.id.toString();

          let bodyDiv = document.createElement("div");
          bodyDiv.classList.add("body");

          let descriptionParagraph = document.createElement("p");
          descriptionParagraph.textContent = newReport.description;
          bodyDiv.appendChild(descriptionParagraph);

          let titleDiv = document.createElement("div");
          titleDiv.classList.add("title");

          let authorSpan = document.createElement("span");
          authorSpan.classList.add("author");
          authorSpan.textContent = "Submitted by: " + newReport.author;

          let statusSpan = document.createElement("span");
          statusSpan.classList.add("status");
          statusSpan.textContent = newReport.status.toString() + " | " + newReport.severity.toString();

          titleDiv.appendChild(authorSpan);
          titleDiv.appendChild(statusSpan);

          reportDiv.appendChild(bodyDiv);
          reportDiv.appendChild(titleDiv);

          return reportDiv;
     }

     function compareProperties(a, b) {
          if (a > b) {
               return 1;
          } else if (a === b) {
               return 0;
          } else {
               return -1;
          }
     }

     let resultObj = {
          report: function (author, description, reproducible, severity) {
               let newReport = {
                    id: id,
                    author: author,
                    description: description,
                    reproducible: reproducible,
                    severity: severity,
                    status: "Open"
               };

               id++;

               let contentDiv = document.querySelector("#content");
               let reportDiv = generateReportDiv(newReport);
               contentDiv.appendChild(reportDiv);

               bugReports.push(newReport);
          },
          setStatus: function (id, newStatus) {
               Array.from(bugReports).find((bug) => bug.id === id).status = newStatus;
               refreshReports(bugReports);
          },
          remove: function (id) {
               bugReports = Array.from(bugReports).map((bug) => {
                    if (bug.id === id) {
                    } else {
                         return bug;
                    }
               }).filter(x => {
                    if (x === undefined) {
                         return false;
                    }
                    return true;
               });

               refreshReports(bugReports);
          },
          output: function (selector) {
               let parent = document.querySelector("#content").parentElement;
               parent.classList.add(selector);
          },
          sort: function (method) {
               let tempReports = bugReports.slice(0);

               if (method === "author") {
                    tempReports = Array.from(tempReports).sort((a, b) => compareProperties(a.author, b.author));
               } else if (method === "ID") {
                    tempReports = Array.from(tempReports).sort((a, b) => compareProperties(a.id, b.id));
               } else if (method === "severity") {
                    tempReports = Array.from(tempReports).sort((a, b) => compareProperties(a.severity, b.severity));
               } else {
                    tempReports = Array.from(tempReports).sort((a, b) => compareProperties(a.id, b.id));
               }

               refreshReports(tempReports);
          }
     };

     return resultObj;
}