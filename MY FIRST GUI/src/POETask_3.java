import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

import javax.swing.JOptionPane;

public class POETask_3 {
	static Scanner Return = new Scanner(System.in);
	static String Answer_12;
	static int Answer_2;
	static int Answer_3 ;
	static int sum;
	static String Top = "To Do";
	static String Middle = "Doing";
	static String Down = "Done";
	static ArrayList<String> Developer_1 = new ArrayList<>();
	static ArrayList <String> Task_Name_1 = new ArrayList<>();
	static ArrayList <Integer> Task_Duration_1 = new ArrayList<>();
	static ArrayList <String> Task_ID = new ArrayList<>();
	static ArrayList <String> Task_Status_1= new ArrayList<>();
	public static void main(String[] args) {
		
		
		task_2();
		checklength(null);
		
		Back();
	
		
	}
    public static void task_2() {
    	try {
			BufferedWriter Print = new BufferedWriter(new FileWriter("Data.txt"));
			System.out.println("-----------------------------------------------");
			System.out.println(" Welcome to Kanban :) ");
			System.out.println("-----------------------------------------------");
			System.out.println(" MAIN MENU ");
			
			System.out.println("1. ADD TASK");
			System.out.println("2. SHOW REPORT");
			System.out.println("3. QUIT");
			System.out.print("Enter Answer :");
			int Answer = Return.nextInt();
			
			 if (Answer == 1) {
				 System.out.println("How mank tasks do you want to add");
			 Answer_3 = Return.nextInt();
			 
			
			 
		    try {
			for (int loop=0; loop<Answer_3; loop++) {
				
				System.out.println();
				System.out.println("which task do you want to do");
				System.out.println("1. To Do ");
				System.out.println("2. Doing ");
				System.out.println("3. Done  ");
				System.out.println(" ");
				System.out.println("4. stop ");
				System.out.print("Enter Answer : ");
			 Answer_2 = Return.nextInt()	;
			
			if (Answer_2 ==1 || Answer_2 == 2|| Answer_2 == 3) {
				   
				  System.out.println("----------------------------------");
		    	  System.out.print("Enter Task name : ");
		    	  String Answer_1 = Return.next();
		    	  Task_Name_1.add(loop, Answer_1) ;
		    	  Print.write("\n" +Answer_1);
		    	  System.out.println("Task number : " + loop);
		    	  
		    	  System.out.print("Task description : ");
		    	  String Answer_10 = Return.next();
		    	  checklength(Answer_10) ;
		    	  System.out.print("Developer's name : ");
		    	  String Answer_3 = Return.next();
		    	  Developer_1.add(loop, Answer_3);
		    	  Print.write("\n" +Answer_3);
		    	  System.out.print("Task duration : ");
		    	  int Answer_5 = Return.nextInt();
		    	  Task_Duration_1.add(loop, Answer_5);
		    	  Print.write("\n" +Answer_5);
		    	  sum = sum + Task_Duration_1.get(loop); 
		    	
	            
	            	String first = Task_Name_1.get(loop).substring(0,2).toUpperCase();
	            	String last = Developer_1.get(loop).substring(Developer_1.get(loop).length() - 3).toUpperCase();
	            	 Task_ID.add(loop, first + ":" +"0" + (loop +1) + ":" + last);
	              System.out.println("Task ID : " + Task_ID.get(loop));
	              Print.write("\n" +Task_ID.get(loop));
	              if (Answer_2 ==1) {
	            	  Task_Status_1.add(loop,Top);
	              System.out.println("Task status : "+ Task_Status_1.get(loop));
	              Print.write("\n" +Top); 
	              }
	              if (Answer_2 ==2) {
	            	  Task_Status_1.add(loop,Middle);
		              System.out.println("Task status : " +Task_Status_1.get(loop));
		              Print.write("\n" +Middle); 
		              }
	              if (Answer_2 ==3) {
	            	  Task_Status_1.add(loop,Down);
		              System.out.println("Task status : " + Task_Status_1.get(loop));
		              Print.write("\n" +Down); 
		              }
	              
	            	
			
			}
			else {
				System.out.println("Bye bye");
			}
			
		    }
			
		}catch (Exception e1) {
			
		}
			 }
			 if (Answer == 2) {
				Back();
			 }
			 if (Answer == 3) {
				 System.exit(0);
				 System.out.println("Bye bye ");
				
			 }
			 Print.close();
		} catch (IOException e) {
			
			e.printStackTrace();
		}
    	
		
  }
  
    
public static void checklength(String Answer_10) {
	try {if( Answer_10.length() < 50) {
		System.out.println("captured succesfully");
	}
	else {
		System.out.println("Please enter a task description of less than 50 character");
	}
	}catch (Exception e1) {
		System.out.println("--------------------------------------------------");
		System.out.println("thank you");
		
		System.out.println("--------------------------------------------------");
		System.out.println("Accumulated hours :" + sum );
		System.out.println("");
		System.out.println("-------------------------------------------------");
		
		
	}
	

	
}

public static void file() {
	try {
		BufferedReader reader = new BufferedReader(new FileReader("Data.txt"));
		System.out.println(reader.readLine());
		reader.close();
	} catch (IOException e) {
		
		e.printStackTrace();
	}
}
public static void Back() {
	    System.out.println("");
	    System.out.println("");
	    System.out.println("-----------------------------------------------------");
		System.out.println("Which task do you want to see ");
		System.out.println("-----------------------------------------------------");

		System.out.println("1. To Do ");
		System.out.println("2. Doing ");
		System.out.println("3. Done  ");
		System.out.println("4. The longest durational task");
		System.out.println("5. Search by developer's Name ");
		System.out.println("6. Show All Tasks");
		System.out.println("8. Do you wish to delete a task ");
		System.out.println("");
		System.out.println("7. Menu");
		
		System.out.print("Enter Answer : ");
		
		int Answer_10 = Return.nextInt();
		if (Answer_10 == 1) {
			To_Do();
		}
		else if (Answer_10 == 2) {
			doing();
			
		}
		else if (Answer_10 == 3) {
			
			done();
		
	}
		else if (Answer_10 == 4) {
			longest_Duration();
		}
		else if (Answer_10 == 5) {
			search();
		}
		else if (Answer_10 == 6) {
			Show_All();
		}
		else if (Answer_10 == 7) {
			task_2();
		}
		else if (Answer_10 == 8) {
			Remove();
		}
	}

 public static void To_Do() {
if (Task_Name_1.size() != 0)	{
	 for (int i = 0; i < Task_Status_1.size(); i++) {
		if(Task_Status_1.get(i).equals("To Do")) {
	System.out.println("------------------------------------------------------");
	System.out.println("Task Name :" + Task_Name_1.get(i));
	System.out.println("Developer Name :" + Developer_1.get(i));
	System.out.println("Task Duration :"+ Task_Duration_1.get(i));
	System.out.println("Task Status :" + Task_Status_1.get(i));
	System.out.println("Task ID :" + Task_ID.get(i));
	System.out.println("-------------------------------------------------------");
		}
		
}
}else {System.out.println("Please input data First");}

System.out.println("");
System.out.println();
	 
 }

public static void done() {
	if (Task_Name_1.size() != 0)	{
	for (int i = 0; i <Task_Status_1.size();i++)
	if(Task_Status_1.get(i).equals("Done")) {
		System.out.println("------------------------------------------------------");
		System.out.println("Task Name :" + Task_Name_1.get(i));
		System.out.println("Developer Name :" + Developer_1.get(i));
		System.out.println("Task Duration :"+ Task_Duration_1.get(i));
		System.out.println("Task Status :" + Task_Status_1.get(i));
		System.out.println("Task ID :" + Task_ID.get(i));
		System.out.println("-------------------------------------------------------");
			}
	}else { System.out.println("Please input data First");}
	
			}
	

public static void doing () {
	if (Task_Name_1.size() != 0)	{
	for(int i = 0; i < Task_Status_1.size();i++)
	if(Task_Status_1.get(i).equals("Doing")) {
		System.out.println("------------------------------------------------------");
		System.out.println("Task Name :" + Task_Name_1.get(i));
		System.out.println("Developer Name :" + Developer_1.get(i));
		System.out.println("Task Duration :"+ Task_Duration_1.get(i));
		System.out.println("Task Status :" + Task_Status_1.get(i));
		System.out.println("Task ID :" + Task_ID.get(i));
		System.out.println("-------------------------------------------------------");
			}
	}else {System.out.println("Please input data First");}
			}

public static void longest_Duration() {
	int highest = Collections.max(Task_Duration_1 ); 
	int k = Task_Duration_1.indexOf(highest);
	System.out.println("------------------------------------------------------");
	System.out.println("Task Name :" + Task_Name_1.get(k));
	System.out.println("Developer Name :" + Developer_1.get(k));
	System.out.println("Task Duration :"+ Task_Duration_1.get(k));
	System.out.println("Task Status :" + Task_Status_1.get(k));
	System.out.println("Task ID :" + Task_ID.get(k));
	System.out.println("-------------------------------------------------------");
	
	System.out.println("Do you wish to go back to MENU");
	
}

public static void search() {
	System.out.println("");
	System.out.println("how many developers do you want to search ");
	int Answer_11 = Return.nextInt();
	if (Answer_11> Developer_1.size()) {
		System.out.println("YOUR RANGE IS OUT OF BOUND PLEASE REDUCE , PLEASE TRY AGAIN");
		search();
	}else {
	for(int i = 0 ; i<Answer_11;i++) {
	System.out.print("Enter developer number "+(i + 1)+" : ");
	String Answer_12 = Return.next();   
	int t = Developer_1.indexOf(Answer_12);
	System.out.println("------------------------------------------------------");
	System.out.println("Task Name :" + Task_Name_1.get(t));
	System.out.println("Developer Name :" + Developer_1.get(t));
	System.out.println("Task Duration :"+ Task_Duration_1.get(t));
	System.out.println("Task Status :" + Task_Status_1.get(t));
	System.out.println("Task ID :" + Task_ID.get(t));
	System.out.println("-------------------------------------------------------");
	}
}
}
public static void Show_All() {
	if (Task_Name_1.size() != 0 ) {
for (int i =0; i < Task_Name_1.size();i++) {
System.out.println("------------------------------------------------------");
System.out.println("Task Name :" + Task_Name_1.get(i));
System.out.println("Developer Name :" + Developer_1.get(i));
System.out.println("Task Duration :"+ Task_Duration_1.get(i));
System.out.println("Task Status :" + Task_Status_1.get(i));
System.out.println("Task ID :" + Task_ID.get(i));
System.out.println("-------------------------------------------------------");
}
	
}else {
	System.out.println("NO TASK TO DISPLAY");
}
	}

public static void Remove() {
	System.out.println("");
	System.out.print("How many tasks do you want to delete : ");
	int Answer_16 = Return.nextInt();
	if (Answer_16 > Task_Name_1.size()) {
		System.out.println("YOUR RANGE IS OUT OF BOUND PLEASE REDUCE");
		Remove();
	}else {
		for (int i = 0 ; i < Task_Name_1.size();i++) {
	System.out.print("Enter task name " + (i + 1) + " wish to delete : ");
	String Answer_13 = Return.next();
	if (Task_Name_1.contains(Answer_13)) {
	int z = Task_Name_1.indexOf(Answer_13);
	System.out.println("------------------------------------------------------");
	System.out.println("The Following Task is removed ");
	System.out.println("------------------------------------------------------");
	System.out.println("Task Name :" + Task_Name_1.remove(z));
	System.out.println("Developer Name :" + Developer_1.remove(z));
	System.out.println("Task Duration :"+ Task_Duration_1.remove(z));
	System.out.println("Task Status :" + Task_Status_1.remove(z));
	System.out.println("Task ID :" + Task_ID.remove(z));
	System.out.println("-------------------------------------------------------");
	
	System.out.println("Do you wish to see the updated data : ");
	System.out.println("1. Yes");
	System.out.println("2. No");
	System.out.print("Enter Answer : ");
	int Answer_14 = Return.nextInt();
	if (Answer_14 == 1) {
		Show_All();
	}
	else if (Answer_14 == 2) {
		Back();
	}
	}else {
		System.out.println("Task name does not match the data please try again");
		Remove();
	}
	
}
	}
}
}
	
	



