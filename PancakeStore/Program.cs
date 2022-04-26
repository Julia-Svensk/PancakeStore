using System;

bool done = false;

int PancakePrice = 50;
int JamPrice = 15;
int CreamPrice = 10;
int TotalPrice = 0;

string[] menu = {"Pancakes", "Jam", "Whipped cream"};
int[] prices = {PancakePrice, JamPrice, CreamPrice};

Console.WriteLine("Welcomet to our pancake shop!");
Console.WriteLine("Here is our menu:");

//Prints menu
for(int i = 0; i < 3; i++) {
    Console.WriteLine($"{menu[i]}   {prices[i]}kr");
}

while (done == false) {
    //Pancakes
    int pancakeAmount = 0;
    bool pancakeAmountBool = false;

    while (pancakeAmountBool == false || pancakeAmount < 1 || pancakeAmount > 5) {
        Console.WriteLine(">------------------------<");
        Console.WriteLine("You can only get between 1 and 5 pancakes.");
        Console.WriteLine("How many do you want?");
        pancakeAmountBool = int.TryParse(Console.ReadLine(), out pancakeAmount);
    }
    
    bool Jam = itemRequest("jam");
    bool Cream = itemRequest("whipped cream");

    TotalPrice += pricePerPortion(pancakeAmount, Jam, Cream, PancakePrice, JamPrice, CreamPrice);

    Console.WriteLine("Do you want another portion?");
    Console.WriteLine("If you write anything except for yes I'll assume you're done");
    string morePortion = Console.ReadLine();
    
    if (morePortion == "yes" || morePortion == "Yes") {
        done = false;
    } else {
        done = true;
    }
}

Console.WriteLine("Thank you for coming!");
Console.WriteLine($"In total your order costs {TotalPrice}kr.");
Console.ReadLine();


// -------------------------------------------------------------------------------------------------------------------------- //


//Jam & Cream
static bool itemRequest(string item) {
    bool AnswerBool = false;
    bool wantItem = false;
 
    while (AnswerBool == false) {
        Console.WriteLine($"Do you want {item} on your pancakes?");
        string Answer = Console.ReadLine();
 
        if (Answer == "yes" || Answer == "Yes") {
            AnswerBool = true;
            wantItem = true;
        } 
        else if (Answer == "no" || Answer == "No") {
            AnswerBool = true;
            wantItem = false;
        }
        else
        {
            Console.WriteLine("Write yes or no");
        }
    }
    
    return wantItem;
}

//-----------------------------------------------------------------------------------------------------------//

//Price calculator
static int pricePerPortion(int pancake, bool jam, bool cream, int PancakePrice, int JamPrice, int CreamPrice) {
    int jamCost;
    int creamCost;

    if (jam == true) {
        jamCost = JamPrice;
    }
    else {
        jamCost = 0;
    }
 
    if (cream == true) {
        creamCost = CreamPrice;
    }
    else {
        creamCost = 0;
    }
 
    int price = PancakePrice * pancake + jamCost + creamCost;
 
    Console.WriteLine($"This portion will cost {price}kr.");;
    return price;
}
 
// Introduce menu
// Ask how many pancakes
// Ask if jam
// Ask if cream
// Present price for portion
// Ask if want another portion
    // If yes repeat
    // If no continue
//Add price of all portions
//Present price
//end