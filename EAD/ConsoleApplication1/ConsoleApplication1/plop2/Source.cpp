#include "HotDogStand.h" //Include the .h file of whatever object your are using
#include <iostream>;
#include <string>
#include <iomanip>
#include <cmath>
using namespace std;

int main() {

	int id[2];
	int hotdogs[2];
	

	
	for (int i = 0; i < 2; i++)
	{

		cout << "what is the id number for this stand " << endl;
		cin >> id[i];

		cout << "How many hotdogs did stand " << id[i] << " sell" << endl;
		cin >> hotdogs[i];
	}

	//Create an object like so:
		HotDogStand stand1(id[0], hotdogs[0]);
		HotDogStand stand2(id[1], hotdogs[1]);


	//Call Methods like this:
	stand1.print();
	cout << endl;

	stand2.print();


	system("pause");
	return 0;
}