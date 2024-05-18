import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import javax.swing.JPasswordField;
import java.awt.event.ActionListener;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.awt.event.ActionEvent;
import java.awt.Font;
import javax.swing.SwingConstants;

public class Registration extends JFrame {

	private JPanel contentPane;
	private JTextField textField;
	private JTextField textField_2;
	private JTextField textField_3;
	private JPasswordField passwordField;
	private JLabel lblNewLabel;
	private JLabel lblNewLabel_1;
	private JLabel lblNewLabel_2;
	private JLabel lblNewLabel_3;
	private JButton btnNewButton;
	private JButton btnNewButton_1;
	private JLabel lblNewLabel_4;
	private JLabel lblNewLabel_5;
	private JLabel lblNewLabel_6;
	private JLabel lblNewLabel_7;
	private JLabel lblNewLabel_8;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Registration frame = new Registration();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Registration() {
		setTitle("Registration");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 513, 489);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		lblNewLabel = new JLabel("Usernname");
		lblNewLabel.setBounds(10, 110, 123, 28);
		contentPane.add(lblNewLabel);
		
		lblNewLabel_1 = new JLabel("Password");
		lblNewLabel_1.setBounds(10, 184, 123, 28);
		contentPane.add(lblNewLabel_1);
		
		lblNewLabel_2 = new JLabel("First Name");
		lblNewLabel_2.setBounds(10, 255, 106, 28);
		contentPane.add(lblNewLabel_2);
		
		lblNewLabel_3 = new JLabel("Surname");
		lblNewLabel_3.setBounds(10, 320, 106, 28);
		contentPane.add(lblNewLabel_3);
		
		textField = new JTextField();
		textField.setBounds(182, 114, 250, 20);
		contentPane.add(textField);
		textField.setColumns(10);
		
		textField_2 = new JTextField();
		textField_2.setBounds(182, 259, 250, 20);
		contentPane.add(textField_2);
		textField_2.setColumns(10);
		
		textField_3 = new JTextField();
		textField_3.setBounds(182, 324, 250, 20);
		contentPane.add(textField_3);
		textField_3.setColumns(10);
		
		btnNewButton = new JButton("LOGIN");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String text = textField.getText();
				String password = passwordField.getText();
			    String Name = textField_2.getText();
			    String Surname = textField_3.getText();
				
				lblNewLabel_4 = new JLabel("");
				lblNewLabel_4.setBounds(10, 67, 414, 14);
				contentPane.add(lblNewLabel_4);
				if (text.equals("")) {
					JOptionPane.showMessageDialog(null,"Username must be filled");
				}
				if (password.equals("")) {
					JOptionPane.showMessageDialog(null,"Password must be filled");
				}
				if (text.contains("_") && text.length() < 6 && password.length() < 9) {
					
					lblNewLabel_5.setText("UserName succesfully captured");
					lblNewLabel_6.setText("Welcome "+ Name + Surname + " it is great to see you again. ");
					lblNewLabel_8.setText("Password succesfully captured");
				}
				if (wordP(password) == false && checkpass(password) == false && hasSpecialCharacter(password)== false ) {
					
					JOptionPane.showMessageDialog(null,"Username is not correctly formatted, Please insure that your username contains and underscore and is no more than 5 charecters in length");
					JOptionPane.showMessageDialog(null,"Password not correctly formatted, Please ensure that your password contains atleast 8 characters,A capital letter,A number and a special character");
				
				}
					System.out.println(text + ";" + password);
					System.out.println(wordP(password));
			}
		});
		btnNewButton.setBounds(10, 395, 89, 23);
		contentPane.add(btnNewButton);
		
		btnNewButton_1 = new JButton("CANCEL");
		btnNewButton_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				System.exit(EXIT_ON_CLOSE);
			}
		});
		btnNewButton_1.setBounds(182, 395, 89, 23);
		contentPane.add(btnNewButton_1);
		
		passwordField = new JPasswordField();
		passwordField.setBounds(182, 188, 250, 20);
		contentPane.add(passwordField);
		
		lblNewLabel_5 = new JLabel("");
		lblNewLabel_5.setBounds(10, 149, 422, 14);
		contentPane.add(lblNewLabel_5);
		
		lblNewLabel_6 = new JLabel("");
		lblNewLabel_6.setBounds(10, 370, 422, 14);
		contentPane.add(lblNewLabel_6);
		
		lblNewLabel_7 = new JLabel("Registration");
		lblNewLabel_7.setFont(new Font("Tahoma", Font.BOLD | Font.ITALIC, 16));
		lblNewLabel_7.setBounds(158, 28, 170, 41);
		contentPane.add(lblNewLabel_7);
		
		lblNewLabel_8 = new JLabel("");
		lblNewLabel_8.setBounds(10, 230, 422, 14);
		contentPane.add(lblNewLabel_8);
		
		
	}
	public static boolean wordP (String password) {
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
    	boolean haslow = false;
    	char c;
    	
    	for (int i=0; i < password.length();i++) {
    		
    		c= password.charAt(i);
    		if(Character.isDigit(c)) {
    			hasNum = true;
    		}
    		
    		else if (Character.isUpperCase(c))	{
    			hasCap = true;
    	    }
    		else if (Character.isLowerCase(c)) {
    			haslow = true;
    		}
    		if (hasNum &&  hasCap && haslow) {
    			return true;
    		}
    		}
    	return false;
    	
    }
    public static boolean hasSpecialCharacter(String password) {
    	Pattern sPattern = Pattern.compile("[^A-Za-z0-9]*");
    	Matcher sMatcher = sPattern.matcher(password);
    	
    	if(!sMatcher.matches ()) {
    		return true;
    	}
    	return false;
    }
}
