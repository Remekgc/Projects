import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;

public class ProductManager {
	
	//Counts number of heavy products
	public long getHeavyProducts(List<Product> products) {
		Stream<Product> p = products.parallelStream();
		return p.filter(e -> e.getWeightInGrams()>50000).count();
	}
	
	public boolean checkIfLKW(LKW lkw, List<Product> products) {
		Stream<Product> p = products.parallelStream();
		Stream<Product> p2 = products.parallelStream();
		if(p.mapToDouble(e -> e.getVolumeCM3()).sum()>lkw.getMaxVolumeM3()*1000000)
			return false;
		else if(p2.mapToInt(e -> e.getWeightInGrams()).sum()>lkw.getMaxWeightInKG()*1000)
			return false;
		else
			return true;
	}
	
	public static void main(String[] args)
	{
		Product p = new Product(100, 50001, 100);
		Product p2 = new Product(100, 50001, 100);
		
		LKW lkw = new LKW(200, 100);
		
		List<Product> products = new ArrayList<Product>();
		
		products.add(p);
		products.add(p2);
		
		ProductManager pm = new ProductManager();
		
		System.out.println("Number of heavy products: "+pm.getHeavyProducts(products));
		System.out.println("Is this LKW: "+pm.checkIfLKW(lkw, products));
	}
}