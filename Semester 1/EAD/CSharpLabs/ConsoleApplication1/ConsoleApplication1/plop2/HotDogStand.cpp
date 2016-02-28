//Use CPP files to actually use implement the .h files 

#include <string>
#include <iomanip>
#include <cmath>
#include "HotDogStand.h"
#include <iostream>;
using namespace std;


HotDogStand::HotDogStand()
{

	//Set your values to whatever their default is in the default constructor
	id = 0;
	hotdogs = 0;

}


HotDogStand::HotDogStand(int newId, int newHotdogs)
{
	id = newId;
	hotdogs = newHotdogs;

	//use overloaded construct to initialize your private variables.
}

//Implement Methods from the header like this:
void HotDogStand::print()
{
	cout << "ID number:\t" << id << "\nThe number of hotdogs stand " << id << " sold is:\t" << hotdogs << endl;

}
