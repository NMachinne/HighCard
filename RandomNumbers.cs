internal static class RandomNumbers{
	private static System.Random r;

	internal static int NextNumber(){
		if (r == null)
			nrandom();
		return r.Next();
	}

	internal static int NextNumber(int ceiling){
		if (r == null)
			nrandom();
		return r.Next(ceiling);
	}

	internal static void nrandom(){
		r = new System.Random();
	}
}