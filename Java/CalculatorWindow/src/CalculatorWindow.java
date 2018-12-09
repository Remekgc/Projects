import java.awt.*;
import java.awt.event.*;


public class CalculatorWindow extends java.awt.Frame implements java.awt.event.ActionListener  {
	Frame frame=new Frame();	
	Label x = new Label("x");
	Label y = new Label("y");
	Label result = new Label("Result");
	
	TextField textFieldX = new TextField();
	TextField textFieldY = new TextField();
	TextField textFieldResult = new TextField();
	
	Button buttonAdd = new Button("Add");
	Button buttonSub = new Button("Sub");
	Button buttonMul = new Button("Mul");
	Button buttonDiv = new Button("Div");
	Button buttonSin = new Button("Sin x");
	
	CalculatorWindow()
	{
		x.setBounds(30, 40, 20, 20);
		y.setBounds(30, 60, 20, 20);
		result.setBounds(30, 80, 60, 20);
		
		textFieldX.setBounds(50, 40, 50, 20);
		textFieldY.setBounds(50, 60, 50, 20);
		textFieldResult.setBounds(100, 80, 100, 20);
		
		buttonAdd.setBounds(100, 40, 50, 20);
		buttonSub.setBounds(150, 40, 50, 20);
		buttonMul.setBounds(100, 60, 50, 20);
		buttonDiv.setBounds(150, 60, 50, 20);
		buttonSin.setBounds(200, 50, 50, 20);
		
		//making every button and textfield visible
		add(x); add(y);	add(result);
		 
		add(textFieldX); add(textFieldY); add(textFieldResult);
		
		add(buttonAdd);	add(buttonSub);	add(buttonMul);	add(buttonDiv);	add(buttonSin);
		
		//making buttons responsive to clicks
		
		buttonAdd.addActionListener(this);
		buttonSub.addActionListener(this);
		buttonMul.addActionListener(this);
		buttonDiv.addActionListener(this);
		buttonSin.addActionListener(this);
		
		setLayout(null);
		setVisible(true);
		setSize(270, 130);
		//closing window by X on the right corner
		addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e)
			{
				dispose();
			}
		});
	}
	
	public void actionPerformed(ActionEvent e) {
		double x=Integer.parseInt(textFieldX.getText());
		double y=Integer.parseInt(textFieldY.getText());
		
		//getting value and changing it to string
		
		if(e.getSource()==buttonAdd)
			textFieldResult.setText(String.valueOf(x+y));
		if(e.getSource()==buttonSub)
			textFieldResult.setText(String.valueOf(x-y));
		if(e.getSource()==buttonMul)
			textFieldResult.setText(String.valueOf(x*y));
		if(e.getSource()==buttonDiv)
			textFieldResult.setText(String.valueOf(x/y));
		if(e.getSource()==buttonSin)
			textFieldResult.setText(String.valueOf(Math.sin(x)));
	}
	
	public static void main(String[] args)
	{
		new CalculatorWindow();
	}
}
