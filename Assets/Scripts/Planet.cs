using System;
public class Planet {

	private int size;
	public int metal {get; set;}
	public int deuterium {get; set;}
	private bool isMain {get; set;}

	public int metal_mine_level {get; set;}
	public int metal_up_cost {get; set;}

	public int deut_mine_level {get; set;}
	public int deut_up_cost {get; set;}

	private int travel_cost {get;}

	private Random rnd;
	private int rand_range;

	public int index {get;}
	/* 
		Type
		  0: Rochoso
		  1: Gasoso
		  2: Aquoso (Misto)
	 */
	private int type;

	public Planet(int size, bool isMain, int type, int travel_cost, int index) {
		rnd = new Random();
		this.type = type;
		rand_range = GlobalData.RESOURCES_RAND_RANGE;
		int metal_random;
		int deuterium_random;
		int metal_cost;
		int deut_cost;
		if(type == 0) {
			metal_random = (rnd.Next(rand_range) + size) * 10;
			metal_cost = (size + rnd.Next(rand_range)) * 1;
			deuterium_random = (rnd.Next(rand_range) + size) * 3;
			deut_cost = (size + rnd.Next(rand_range)) * 3;
		}
		else if(type == 1) {
			metal_random = (rnd.Next(rand_range) + size) * 3;
			metal_cost = (size + rnd.Next(rand_range)) * 3;
			deuterium_random = (rnd.Next(rand_range) + size) * 10;
			deut_cost = (size + rnd.Next(rand_range)) * 1;
		}
		else {
			metal_random = (rnd.Next(rand_range) + size) * 6;
			metal_cost = (size + rnd.Next(rand_range)) * 2;
			deuterium_random = (rnd.Next(rand_range) + size) * 4;
			deut_cost = (size + rnd.Next(rand_range)) * 2;
		}

		this.metal = metal_random;
		this.deuterium = deuterium_random;
		this.metal_up_cost = metal_cost;
		this.deut_up_cost = deut_cost;

		this.isMain = isMain;
		this.travel_cost = travel_cost;
		this.metal_mine_level = 1;
		this.deut_mine_level = 0;

		this.index = index;
	}

	public bool upgrade_metal_mine() {
		if(GlobalData.metal >= metal_up_cost) {
			GlobalData.metal -= metal_up_cost;
			metal_mine_level += 1;
			metal_up_cost += (rnd.Next(rand_range) + size);
			return true;
		}
		else {
			return false;
		}
	}

	public bool upgrade_deut_mine() {
		if(GlobalData.metal >= deut_up_cost) {
			GlobalData.metal -= deut_up_cost;
			deut_mine_level += 1;
			deut_up_cost += (rnd.Next(rand_range) + size);
			return true;
		}
		else {
			return false;
		}
	}

	public void mine_metal() {
		if(metal > 0) {
			if(metal >= metal_mine_level) {
				metal -= metal_mine_level;
				GlobalData.metal += metal_mine_level;
			}
			else {
				GlobalData.metal += metal;
				metal = 0;
			}
		}
	}

	public void mine_deut() {
		if(deuterium > 0) {
			if(deuterium >= deut_mine_level) {
				deuterium -= deut_mine_level;
				GlobalData.deuterium += deut_mine_level;
			}
			else {
				GlobalData.deuterium += deuterium;
				deuterium = 0;
			}
		}
	}


}