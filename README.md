# Salesforce-Profile-Refactor

A Utility for reducing the size of your Profiles by extracting common elements and placing in a common Permission Set. 

The input is any number of Profile metadata files that you feel are similar. The output is those same Profiles with the common elelements removed, as well as a new Permission Set file that contains the common elements.

Full blog post here: https://andrewwhitten.wordpress.com/2020/12/29/creating-a-salesforce-permission-set-subset-from-multiple-profiles/

The example used (and you can run yourself from the example files provided in the /Build directory) is around a set of Apex Class files, of which some are shared between all three Profiles:

<IMG SRC="https://github.com/andrewwhitten/Salesforce-Profile-Refactor/blob/main/media/PSStep1.png"></IMG>

Using the utility we can extract the two common elements and place in a seperate Permission Set:

<IMG SRC="https://github.com/andrewwhitten/Salesforce-Profile-Refactor/blob/main/media/PSStep2.png"></IMG>

We can also run again with the two Profiles that have remaining elements and optimize with an additional Permission Set. 

<IMG SRC="https://github.com/andrewwhitten/Salesforce-Profile-Refactor/blob/main/media/PSStep3.png"></IMG>


You can run the tool from the command line on MacOS, Windows or Linux:

<IMG SRC="https://github.com/andrewwhitten/Salesforce-Profile-Refactor/blob/main/media/Console.png"></IMG>

And the output files will be written to a directory. They are ready to use at this point:

<IMG SRC="https://github.com/andrewwhitten/Salesforce-Profile-Refactor/blob/main/media/Output.png"></IMG>


