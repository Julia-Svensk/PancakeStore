using System;

bool done = false;

int pancakePrice = 50;
int jamPrice = 15;
int creamPrice = 10;
int totalPrice = 0;

string[] menu = {"Pancakes", "Jam", "Whipped cream"};
int[] prices = {pancakePrice, jamPrice, creamPrice};

Console.WriteLine("Welcome to our pancake shop!");
Console.WriteLine("Here's our menu:");

//Prints menu
for(int i = 0; i < 3; i++) {
    Console.WriteLine($"{menu[i]}   {prices[i]}kr");
}

while (done == false) {
    //Pancakes
    int pancakeAmount = 0;
    bool pancakeAmountBool = false;

    Console.WriteLine(">------------------------<");

    while (pancakeAmountBool == false || pancakeAmount < 1 || pancakeAmount > 5) {
        Console.WriteLine("We offer between 1 and 5 pancakes. PLease choose an amount within that range.");
        Console.WriteLine("How many do you want?");
        pancakeAmountBool = int.TryParse(Console.ReadLine(), out pancakeAmount);
    }
    
    bool jam = Itemrequest("jam");
    bool cream = Itemrequest("whipped cream");

    totalPrice += PricePerPortion(pancakeAmount, jam, cream, pancakePrice, jamPrice, creamPrice);

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
Console.WriteLine($"In total your order costs {totalPrice}kr.");
Console.ReadLine();


// -------------------------------------------------------------------------------------------------------------------------- //


//jam & cream
static bool Itemrequest(string item) {
    bool answerBool = false;
    bool wantItem = false;
 
    while (answerBool == false) {
        Console.WriteLine($"Do you want {item} on your pancakes?");
        string answer = Console.ReadLine();
 
        if (answer == "yes" || answer == "Yes") {
            answerBool = true;
            wantItem = true;
        } 
        else if (answer == "no" || answer == "No") {
            answerBool = true;
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
static int PricePerPortion(int pancake, bool jam, bool cream, int pancakePrice, int jamPrice, int creamPrice) {
    int jamCost;
    int creamCost;

    if (jam == true) {
        jamCost = jamPrice;
    }
    else {
        jamCost = 0;
    }
 
    if (cream == true) {
        creamCost = creamPrice;
    }
    else {
        creamCost = 0;
    }
 
    int price = pancakePrice * pancake + jamCost + creamCost;
 
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