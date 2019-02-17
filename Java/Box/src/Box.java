public class Box{
	private int index;
	private Element<?>[] elements;
	
	Box(int n)
	{
		if(n>0)
		{
			this.elements = new Element<?>[n];
			this.index=0;
		}else
			throw new IllegalArgumentException("Elements in an array cannot be lower or equal 0.");
	}
	//printing all elements from array
	public void getElements()
	{
		for (int i = 0; i < this.elements.length; i++) {
	         System.out.println(this.elements[i] + " ");
	      }
	}
	//add element of any type to array
	public void addElement(Element<?> e) throws FullBoxException{
		do{
			if(this.index<=elements.length&&e.getSize()<=elements.length)
			{
				this.elements[this.index] = e;
				this.index++;
			}else
				throw new FullBoxException();
		}while(this.index<e.getSize());
	}
	
	public static void main(String[] args) throws FullBoxException
	{
		Box b = new Box(6);
		b.addElement(new Element<Integer>(100,3));
		b.addElement(new Element<Double>(300.0));
		b.addElement(new Element<String>("Hello"));
		b.addElement(new Element<Character>('X'));
		b.getElements();
	}
}