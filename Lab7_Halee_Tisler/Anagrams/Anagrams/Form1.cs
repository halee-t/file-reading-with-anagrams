using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
LAB #7 
FALL SEMESTER
HALEE, TISLER
I fully understand the following statement.
OU PLAGIARISM POLICY
All members of the academic community at Oakland are expected to practice and uphold ‘standards 
of academic integrity and honesty. An instructor is expected to inform and instruct ‘students about 
the procedures and standards of research and documentation required of students ‘in fulfilling 
course work. A student is expected to follow such instructions and be sure the rules ‘and procedures 
are understood in order to avoid inadvertent misrepresentation of his work. ‘Students must assume 
that individual (unaided) work on exams and lab reports and documentation ‘of sources is expected 
unless the instructor specifically says that is not necessary.
The following definitions are some examples of academic dishonesty:
• Plagiarizing from work of others. Plagiarism is using someone else's work or ideas without 
giving the other person credit; by doing this, a student is, in effect, claiming credit for 
someone else's thinking. Whether the student has read or heard the information he uses, the 
student must document the source of information. When dealing with written sources, a 
clear distinction would be made between quotations (which reproduce information from the 
source word-for-word within quotation marks) and paraphrases (which digest the source 
information and produce it in the student's own words). Both direct quotations and 
paraphrases must be documented. Just because a student rephrases, condenses or selects 
from another person's work, the ideas are still the other person's, and failure to give credit 
constitutes misrepresentation of the student's actual work and plagiarism of another's ideas. 
Naturally, buying a paper and handing it in as one's own work is plagiarism.
Cheating on lab reports falsifying data or submitting data not based on student's own work.
*/

namespace Anagrams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear the list
            lstAnagrams.Items.Clear();
            
            //create stream readers for the text files
            StreamReader DictFile;
            DictFile = File.OpenText("C:\\Windows\\Temp\\F21\\dict.txt");
            string DictWord;

            StreamReader PalFile;

            string PalWord;

            //create arrays for the text files
            int[] dictArray = new int[26];
            int[] palArray = new int[26];

            //loop that continues until the end of the dict text file
            while (!DictFile.EndOfStream)
            {
                PalFile = File.OpenText("C:\\Windows\\Temp\\F21\\pal.txt");

                DictWord = DictFile.ReadLine();

                //call the Histogram using an array and string for the parameters
                Histo.Histogram.CreateHistogram(dictArray, DictWord);

                //loop that continues until the end of the pal text file 
                while (!PalFile.EndOfStream)
                {
                    PalWord = PalFile.ReadLine();

                    //call the Histogram
                    Histo.Histogram.CreateHistogram(palArray, PalWord);

                    int count = 0; //counter for the matches

                    //loop that continues for the length of the pal array
                    for (int x = 0; x < palArray.Length; x++)
                    {
                        //if the anagrams match, increase the count
                        if (dictArray[x] == palArray[x])
                        {
                            count++; //count increases for every match
                        }
                    }

                    //if you find all of the matches, list them in the list box
                    if (count == 26)
                    {
                        lstAnagrams.Items.Add(DictWord + " -> " + PalWord);
                    }
                }
                //Close the PalFile
                PalFile.Close();
            }

            //Close the DictFile
            DictFile.Close();
        }
    }
}
