using NUnit.Framework;
using DIKUCanteen;
using System; 

namespace DIKUCanteenTests;

public class Tests
{
    [SetUp]
    public void Setup(){
    }

    [TestCase(3, 2)]
    [TestCase(10, 10)]
    [TestCase(2, 5)]
    public void TestCanTakeCup(int cups, int students){
        // create canteen object
        Canteen canteen = new Canteen("kantinen", cups);
         

        // loop
        for (int i = 0; i < students; i++){
            // create student object
            Student student = new Student("Ignacio Fernandiz", "Historian", 68) ;
            // take a cup from the canteen
            student.TakeCup(canteen);
            // return a cup to the canteen

        }

        Assert.AreEqual(canteen.Cups, Math.Max(0, cups - students));
    }

    // test CanteenBoardMember can take cup
    [Test]
    public void TestCanteenBoardMemberCanTakeAndReturnCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
        // create canteen board member object
        CanteenBoardMember canteenBoardMember = new CanteenBoardMember("Ignacio Fernandiz", "Historian", 68);
        // take a cup from the canteen
        canteenBoardMember.TakeCup(canteen);
        // return a cup to the canteen
        Assert.AreEqual(canteen.Cups, 2);
        canteenBoardMember.ReturnCup(canteen);
        Assert.AreEqual(canteen.Cups, 3);
    }



    // test cannot take cup, when there are zero cups in the canteen
    [Test]
    public void TestCannotTakeCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 0);
         

        // create student object
        Student student = new Student("Ignacio Fernandiz", "Historian", 68) ;
        // take a cup from the canteen
        student.TakeCup(canteen);

        Assert.AreEqual(canteen.Cups, 0);
    }

    // test can return cup
    [Test]
    public void TestCanReturnCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
         

        // create student object
        Student student = new Student("Ignacio Fernandiz", "Historian", 68) ;
        // take a cup from the canteen
        student.TakeCup(canteen);
        
        Assert.AreEqual(canteen.Cups, 2);
        // return a cup to the canteen
        student.ReturnCup(canteen);

        Assert.AreEqual(canteen.Cups, 3);
    }

    // test can not take cup, if student already has a cup
    [Test]
    public void TestCannotTakeCupIfStudentHasCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
         

        // create student object
        Student student = new Student("Ignacio Fernandiz", "Historian", 68) ;
        // take a cup from the canteen
        student.TakeCup(canteen);

        Assert.AreEqual(canteen.Cups, 2);
        // take a cup from the canteen
        student.TakeCup(canteen);

        Assert.AreEqual(canteen.Cups, 2);
    }

    // test can not return cup, if student does not have a cup
    [Test]
    public void TestCannotReturnCupIfStudentDoesNotHaveCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
         

        // create student object
        Student student = new Student("Ignacio Fernandiz", "Historian", 68) ;
        // return a cup to the canteen
        student.ReturnCup(canteen);

        Assert.AreEqual(canteen.Cups, 3);
    }

    // test student is a person
    [Test]
    public void TestStudentIsPerson(){
        // create student object
        Student student = new Student("Ignacio Fernandiz", "Historian", 68);
        Assert.IsTrue(student is Person);
    }

    // test CanteenBoardMember is a person
    [Test]
    public void TestCanteenBoardMemberIsPerson(){
        // create canteen board member object
        CanteenBoardMember canteenBoardMember = new CanteenBoardMember("Ignacio Fernandiz", "Historian", 68);
        Assert.IsTrue(canteenBoardMember is Person);
    }

    // test canteen is a room
    [Test]
    public void TestCanteenIsRoom(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 123);
        Assert.IsTrue(canteen is Room);
    }

    //CanteenBoardMember can buy cup if CanteenBoardMember.CupBudget is large enough
    [Test]
    public void TestCanteenBoardMemberCanBuyCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
        // create canteen board member object
        CanteenBoardMember canteenBoardMember = new CanteenBoardMember("Ignacio Fernandiz", "Historian", 68);

        // set cup budget
        CanteenBoardMember.CupBudget = 10;
        // buy cup
        canteenBoardMember.BuyCup(canteen);
        Assert.AreEqual(canteen.Cups, 4);
        Assert.AreEqual(CanteenBoardMember.CupBudget, 9);
    }

    //CanteenBoardMember cannot buy cup if CanteenBoardMember.CupBudget is not large enough
    [Test]
    public void TestCanteenBoardMemberCannotBuyCup(){
        // create canteen object
        Canteen canteen = new Canteen("Kantinen", 3);
        // create canteen board member object
        CanteenBoardMember canteenBoardMember = new CanteenBoardMember("Ignacio Fernandiz", "Historian", 68);
        // set cup budget
        CanteenBoardMember.CupBudget = 1;
        // buy cup
        canteenBoardMember.BuyCup(canteen);
        Assert.AreEqual(canteen.Cups, 4);
        Assert.AreEqual(CanteenBoardMember.CupBudget, 0);
        //buy cup
        canteenBoardMember.BuyCup(canteen);
        Assert.AreEqual(canteen.Cups, 4);
        Assert.AreEqual(CanteenBoardMember.CupBudget, 0);
    }

}