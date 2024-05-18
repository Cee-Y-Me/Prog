import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.awt.event.ActionEvent;
import javax.swing.JPasswordField;
import java.awt.Font;
import java.awt.Color;

public class LOGIN extends JFrame  {
	

	private JPanel contentPane;
	private JTextField tfName;
	private JLabel lblmessage;
	private JPasswordField passwordField;
	private JLabel lblNewLabel;
	private JLabel lblpassword;
	private JButton btnOK;
	private JLabel lblNewLabel_2;
	private String UserName;
	private JLabel lblNewLabel_1;
	private JLabel lblNewLabel_4;
    private String password ;
    private static String Answer_5;
    private static String Answer_6;
    private static String Answer_10;
    
    private String good;
    static int n;
	static int sum = 0;
    static int Answer_3;
   
	/**
	 * Launch the application.
	 * @param <interger>
	 */
	public static <interger> void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					LOGIN frame = new LOGIN();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
		 ArrayList<interger> Duration = new ArrayList<interger>();
	}

	/**
	 * Create the frame.
	 */
	public LOGIN() {
		
		setForeground(Color.WHITE);
		setTitle("Welcome");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		lblNewLabel = new JLabel("Username");
		lblNewLabel.setBounds(10, 52, 231, 14);
		contentPane.add(lblNewLabel);
		
		tfName = new JTextField();
		tfName.setBounds(10, 77, 235, 20);
		contentPane.add(tfName);
		tfName.setColumns(10);
		
		lblpassword = new JLabel("Password");
		lblpassword.setBounds(10, 146, 79, 14);
		contentPane.add(lblpassword);
		
		passwordField = new JPasswordField();
		passwordField.setBounds(10, 171, 235, 20);
		contentPane.add(passwordField);
		

		lblmessage = new JLabel("");
		lblmessage.setBounds(10, 202, 414, 14);
		contentPane.add(lblmessage);
		
		btnOK = new JButton("OK");
		btnOK.setFont(new Font("Tahoma", Font.BOLD, 11));
		btnOK.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				UserName = tfName.getText();
				password = passwordField.getText();
				
				System.out.println(checkPasswordComplexity(password));
				System.out.println(hasSpecialCharacter(password));
				
               
				lblNewLabel_2 = new JLabel("");
				lblNewLabel_2.setBounds(10, 166, 414, 14);
				contentPane.add(lblNewLabel_2);
				if (UserName.equals("")) {
					JOptionPane.showMessageDialog(null,"Username must be filled");
				}
				if (password.equals("")) {
					JOptionPane.showMessageDialog(null,"Password must be filled");
				}
				if (checkPasswordComplexity(password) == false) {
					JOptionPane.showMessageDialog(null,"Password not correctly formatted, Please ensure that your password contains atleast 8 characters,A capital letter,A number and a special character");
				}
				if (UserName.contains("_") && UserName.length() < 6) {
					
					JOptionPane.showMessageDialog(null,"UserName succesfully captured");
				}
				if (!UserName.contains("_") && UserName.length() > 6) {
					JOptionPane.showMessageDialog(null,"UserName not correctly formatted, Please ensure that it contains an Underscore and is 5 characters in length");
				}
		      if(checkUserName(UserName) == true && checkPasswordComplexity(password) == true) {
		    	// Kanban First = new Kanban();
		    	// First.show();
		    	  System.out.println(UserName + ";" + password);
					
					System.out.println(" ");
					System.out.println(" ");
					System.out.println(" ");
					System.out.println(" ");
					System.out.println(" ");
					
					ProgTask_2 mew = new ProgTask_2();		
					mew.main(null);
				  
			}
			
				
			}
           // public static void Character () {}
			 public static boolean checkUserName(String UserName) {
		    	 if (UserName.contains("_") && UserName.length() < 6) {
						
					return true;
					}
					
					else {
						return false;
					}
		    	
		    }
			
		});
		btnOK.setBounds(10, 227, 91, 23);
		contentPane.add(btnOK);
		
		JButton btnNewButton = new JButton("Registration");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Registration rp = new Registration();
				rp.show();
				
				
						
			}
		});
		btnNewButton.setBounds(213, 227, 104, 23);
		contentPane.add(btnNewButton);
		
		JLabel lblNewLabel_3 = new JLabel("LOGIN");
		lblNewLabel_3.setFont(new Font("Tahoma", Font.BOLD, 17));
		lblNewLabel_3.setBounds(184, 11, 104, 50);
		contentPane.add(lblNewLabel_3);
		
		JLabel lblNewLabel_1 = new JLabel("");
		lblNewLabel_1.setBounds(10, 108, 414, 14);
		contentPane.add(lblNewLabel_1);
		
		lblNewLabel_4 = new JLabel("");
		lblNewLabel_4.setBounds(10, 202, 414, 14);
		contentPane.add(lblNewLabel_4);
	
		

	}
	
	public static boolean checkPasswordComplexity (String password) {
		if (password.length() < 9) {
			if (checkpass (password)) {
				return true;
			}
			else {
				return false;
			}
		
		  }
		else {
			return false;
		}
		
		}

    public static boolean checkpass(String password) {

    	boolean hasNum = false;
    	boolean hasCap = false;
    	char c;
    	
    	for (int i=0; i < password.length();i++) {
    		
    		c= password.charAt(i);
    		if(Character.isDigit(c)) {
    			hasNum = true;
    		}
    		
    		else if (Character.isUpperCase(c))	{
    			hasCap = true;
    	    }
    		
    		if (hasNum &&  hasCap ) {
    			return true;
    		}
    		}
    	return false;
    	
    }
    public static boolean isSpace(String password) {
    	for(char currentChar : password.toCharArray()) {
    		if (Character.isWhitespace(currentChar)) {
    			return true;
    		}
    	}
    	return false;
    }
    
    public static boolean hasSpecialCharacter(String password) {
    	Pattern sPattern = Pattern.compile("[^A-Za-z0-9]");
    	Matcher sMatcher = sPattern.matcher(password);
    	
    	if(!sMatcher.matches ()) {
    		return true;
    	}
    	return false;
    }
}
	

