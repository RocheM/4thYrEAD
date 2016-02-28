#pragma once
class HotDogStand
{
public:
	HotDogStand(); //Default Constructor (Takes no parameters)
	HotDogStand(int newId, int newHotdogs); //Overloaded Constructor (Takes parameters)

									 //Public Variables and Methods go Here
	void print();


private:
	//Private Variables and Methods go Here
	int id;
	int hotdogs;

};

