public class LKW {

	//Max weight in kilograms which can take LKW.

	private final int maxWeightInKG;
	
	//Max volume in M3 which can take LKW.

	private final double maxVolumeM3;
	
	public LKW(int maxWeightInKG, double maxVolumeM3) {
		this.maxWeightInKG = maxWeightInKG;
		this.maxVolumeM3 = maxVolumeM3;
	}
	
	public int getMaxWeightInKG() {
		return this.maxWeightInKG;
	}
	public double getMaxVolumeM3() {
		return this.maxVolumeM3;
	}
}