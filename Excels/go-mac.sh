#!/bin/bash

xlslist=`ls xls/*.xls`  
for xls in $xlslist
do  
echo $xls
sheet=${xls:4:${#xls}-8}"Table"
# SHEET=$(echo $sheet | tr '[a-z]' '[A-Z]')
python tool/xls_deploy_tool.py $sheet $xls
mono protogen/bin/protogen.exe -i:"proto/"$sheet".proto" -o:"../Assets/Scripts/Sheet/"$sheet".cs"
done
echo
read -p "Press any key to continue"