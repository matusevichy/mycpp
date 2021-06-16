#include "Calcstring.h"

void Calcstring::set()
{
	cout << "Enter expression:\n";
	getline(cin,str);
}

void Calcstring::calculateString()
{
	str.erase(remove(str.begin(), str.end(), ' '), str.end());
	smatch res, tmp;
	openBrackets(numExp, allOperationExp);
	parseStr(str, numExp, proddivExp);
	parseStr(str,numExp, sumdifExp);
}

void Calcstring::openBrackets(const string& numExp, const string& operExp)
{
	smatch res, tmp;
	regex reg("\\([^()]+\\)");
	regex tmpreg("[^()]+");
	regex reg1(numExp + operExp + numExp);
	while (regex_search(str, res, reg))
	{
		string str1 = res[0];
		regex_search(str1, tmp, tmpreg);
		string str3 = tmp[0];
		parseStr(str3, numExp, proddivExp);
		parseStr(str3, numExp, sumdifExp);
		str = regex_replace(str, reg, str3, regex_constants::format_first_only);
	}
}

void Calcstring::parseStr(string& str, const string& numExp, const string& operExp)
{
	smatch tmp;
	regex reg2(numExp + operExp + numExp);
	while (regex_search(str, tmp, reg2))
	{
		string str3 = tmp[0];
		calcAndReplace(str, str3, reg2);
	}
}

void Calcstring::calcAndReplace(string& str, string str2, regex reg)
{
	smatch tmp;
	regex reg2("[^\\d.]");
	regex_search(str2, tmp, reg2);
	double first = stod(tmp.prefix().str());
	double second = stod(tmp.suffix().str());
	double result;
	if (tmp[0].str() == "+")
	{
		result = first + second;
	}
	else if (tmp[0].str() == "-")
	{
		result = first - second;
	}
	else if (tmp[0].str() == "/")
	{
		result = first / second;
	}
	else if (tmp[0].str() == "*")
	{
		result = first * second;
	}
	str = regex_replace(str, reg, to_string(result), regex_constants::format_first_only);
}
