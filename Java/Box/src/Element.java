class Element<T> {	//making class with generic type T
	private T value; 
	private int size;
	Element(T value, int size)  
	{
		this.value = value;
		this.size = size;
	}
	Element(T value)
	{
		this.value = value;
		this.size=1;
	}
	public int getSize()
	{
		return this.size;
	}
	public T getValue()
	{
		return this.value;
	}
	public String toString()
	{
		return this.value.toString();
	}

}




