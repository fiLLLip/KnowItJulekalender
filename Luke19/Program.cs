using System;
using System.Collections.Generic;

namespace Luke19
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var source =
                "JegtroringenkanleveetheltlivutenkjærlighetMenkjærlighetenharmangeansikterIhøstkomdetutenboksomheterErlikKjærlighetDenbeståravsamtalermedselgereavgatemagasinetsomnåeretablertimangenorskebyerAllehardeenhistorieåfortelleomkjærlighetsomnoeavgjørendeEntendetertilenpartneretfamiliemedlemenvennelleretkjæledyrMangeharopplevdåblisveketogselvåsvikteMenutrolignokblirikkekjærlighetsevnenødelagtallikevelDenbyggesoppigjengangpågangKjærligheteneretstedåfesteblikketDengirossretningognoeåstyreetterDengirossverdisommenneskerognoeåleveforPåsammemåtesomkjærligheteneretfundamentimenneskeliveterGrunnlovenetfundamentfornasjonenNorgeFor200årsidensamletengruppemennsegpåEidsvollforålagelovensomskullebligrunnlagettildetselvstendigeNorgeGrunnlovensomdengangblevedtattharutvikletsegipaktmedtidenogsikreridagdetnorskefolkrettigheterviletttarforgittihverdagenRettighetersommenneskerimangeandrelandbarekandrømmeomogsomdeslossformedlivetsominnsatsJeghåperatvigjennomjubileumsfeiringeni2014vilbliminnetomhvaGrunnlovenegentligbetyrforosssåvikanfortsetteåarbeideforverdienevårebådeherhjemmeoginternasjonaltJegharlysttilånevnenoeneksemplerpåhvordanGrunnlovenvirkerinnpåenkeltmenneskerslivTenkdegatduskriveretkritiskinnleggomlandetsstyrepåsosialemedier";
            source = source.ToLower();
            Console.WriteLine(GetMaxPalindromeString(source));
            Console.ReadLine();
        }

        public static string GetMaxPalindromeString(string testingString)
        {
            int stringLength = testingString.Length;
            int maxPalindromeStringLength = 0;
            int maxPalindromeStringStartIndex = 0;

            for (int i = 0; i < stringLength; i++)
            {
                int currentCharIndex = i;

                for (int lastCharIndex = stringLength - 1; lastCharIndex > currentCharIndex; lastCharIndex--)
                {
                    if (lastCharIndex - currentCharIndex + 1 < maxPalindromeStringLength)
                    {
                        break;
                    }

                    bool isPalindrome = true;

                    if (testingString[currentCharIndex] != testingString[lastCharIndex])
                    {
                        continue;
                    }
                    else
                    {
                        int matchedCharIndexFromEnd = lastCharIndex - 1;

                        for (int nextCharIndex = currentCharIndex + 1; nextCharIndex < matchedCharIndexFromEnd; nextCharIndex++)
                        {
                            if (testingString[nextCharIndex] != testingString[matchedCharIndexFromEnd])
                            {
                                isPalindrome = false;
                                break;
                            }
                            matchedCharIndexFromEnd--;
                        }
                    }

                    if (isPalindrome)
                    {
                        if (lastCharIndex + 1 - currentCharIndex > maxPalindromeStringLength)
                        {
                            maxPalindromeStringStartIndex = currentCharIndex;
                            maxPalindromeStringLength = lastCharIndex + 1 - currentCharIndex;
                        }
                        break;
                    }
                }
            }

            if (maxPalindromeStringLength > 0)
            {
                return testingString.Substring(maxPalindromeStringStartIndex, maxPalindromeStringLength);
            }

            return null;

        }
    }
}