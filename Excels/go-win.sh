#!/bin/bash
# read -p "请输入要转的表格（直接回车转所有表格）：" name
# if [ -z $name ]; then 
    xlslist=`ls xls/*.xls`  
    for xls in $xlslist
    do  
    echo $xls
    sheet=${xls:4:${#xls}-8}"Table"
    # SHEET=$(echo $sheet | tr '[a-z]' '[A-Z]')
    python tool/xls_deploy_tool_win.py $sheet $xls
    protogen/bin/protogen.exe -i:"proto/"$sheet".proto" -o:"../Assets/Scripts/Sheet/"$sheet".cs"
    done
# else
#     sheet=$name"Table"
#     xls="xls/"$name".xls"
#     python tool/xls_deploy_tool.py $sheet $xls
#     protogen/bin/protogen.exe -i:"proto/"$sheet".proto" -o:"../Assets/Scripts/Sheet/"$sheet".cs"
# fi
echo
read -p "Press any key to continue"