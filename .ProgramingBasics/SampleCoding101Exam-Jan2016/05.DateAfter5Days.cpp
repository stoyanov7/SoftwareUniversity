#include<iostream>
using namespace std;

int main() {
	int day;
	cin >> day;

	int month;
	cin >> month;

	switch(month) {
		case 2:
			if (day + 5 > 28) {
				month++;
				day = day + 5 - 28;
			}
			else {
				day += 5;
			}
			break;
		case 4:
		case 6:
		case 9:
		case 11:
			if (day + 5 > 30) {
				month++;
				day = day + 5 - 30;
			}
			else {
				day += 5;
			}
			break;
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
			if (day + 5 > 31) {
				month++;
				day = day + 5 - 31;
			}
			else {
				day += 5;
			}
			break;
		case 12:
			if (day + 5 > 31) {
				month = 1;
				day = day + 5 - 31;
			}
			else {
				day += 5;
			}
			break;
		default:
			break;
	}

	cout << day << ".";
	if (month < 10) {
		cout << "0";
	}
  	cout << month;
}
