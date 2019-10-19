function validate() {
    let yearElement = document.getElementById('year');
    let monthElement = document.getElementById('month');
    let dateElement = document.getElementById('date');
    let maleElement = document.getElementById('male');
    let femaleElement = document.getElementById('female');
    let regionCode = document.getElementById('region');

    let button = document.querySelector('button');
    let pEgn = document.getElementById('egn');

    button.addEventListener('click', event => {
        if (isYearValid(yearElement.value) && isRegionCodeValid(regionCode.value)) {
            let year = getYearDigits(yearElement.value);
            let month = addZeroToNumber(monthElement.selectedIndex);
            let date = addZeroToNumber(dateElement.value);
            let region = regionCode.value.slice(0, 2);
            let gender = maleElement.checked ? 2 : 1;
            let egnResult = `${year}${month}${date}${region}${gender}`

            pEgn.textContent = `Your EGN is: ${egnResult}${getControlDigit(egnResult)}`;
        }

        year.value = ''
        monthElement.value = '';
        dateElement.value = '';
        maleElement.checked = false;
        femaleElement.checked = false;
        regionCode.value = '';
    })

    /**
     * Get the latest two digits from given year.
     * @param {*} year
     */
    function getYearDigits(year) {
        return year.substring(year.length - 2);
    }

    /**
     * Check if the input year is in given range.
     * @param {*} year The input year for validation.
     */
    function isYearValid (year) {
        return year >= 1900 && year <= 2100; 
    }

    /**
     * Check if the giver region is in valid range.
     * @param {*} regionCode 
     */
    function isRegionCodeValid(regionCode) {
        return regionCode >= 43 && regionCode <= 999;
    }

    function addZeroToNumber(n) {
        if (n < 10) {
            return `0${n}`;
        }

        return n;
    }

    function getControlDigit(egn) {
        let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let sum = 0;

        for (let i = 0; i < egn.length; i++) {
            sum += Number(egn[i] * weightPosition[i]);
        }

        let controlDigit = sum % 11 <= 9 ? sum % 11 : 0;

        return controlDigit;
    }
}