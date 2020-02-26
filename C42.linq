<Query Kind="Program">
  <NuGetReference>morelinq</NuGetReference>
</Query>

/*

--- Part Two ---
Now find one that starts with six zeroes.

Your puzzle input is ckczppom.
*/

void Main()
{
	var secretKey = "ckczppom";
	var md5 = System.Security.Cryptography.MD5.Create();

	var q = from n in Enumerable.Range(1, 10000000)
			let inputString = $"{secretKey}{n}"
			let inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString)
			let hashBytes = md5.ComputeHash(inputBytes)
			let hashString = BitConverter.ToString(hashBytes).Replace("-", "")
			where hashString.StartsWith("000000")
			select new { n, hashString };

	q.FirstOrDefault().Dump();
}

// Define other methods and classes here
