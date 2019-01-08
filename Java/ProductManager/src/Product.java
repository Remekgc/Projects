public class Product {

	//Weight in grams.

	private final int weightInGrams;

	//Price in PLN.

	private final int price;
	
	//Volume in CM3;
	
	private final double volumeCM3;
	
	//Makes new product with given values.
	 
	public Product(int price, int weightInGrams, double volumeCM3) {
		this.price = price;
		this.weightInGrams = weightInGrams;
		this.volumeCM3 = volumeCM3;
	}
	
	public int getPrice() {
		return price;
	}
	public int getWeightInGrams() {
		return weightInGrams;
	}
	public double getVolumeCM3() {
		return volumeCM3;
	}
}
