function solve(anomaly, eccentricity) {
     console.log(Number(approximateFunc(anomaly, eccentricity, 0).toFixed(9)));

     function approximateFunc(E0, eccentricity, series) {
          if (Math.abs(anomaly - (E0 - eccentricity * Math.sign(E0))) < 1e-9 || series > 200) {
               return E0;
          }

          return approximateFunc(E0 - (E0 - eccentricity * Math.sin(E0) - anomaly) / (1 - eccentricity * Math.cos(E0)), eccentricity, ++series);
     }
}