# xls表格转protobuf数据

### 注意事项
* 项目路径不能有空格

### 安装配置
* 安装[python](https://www.python.org/downloads)（这里装的是2.7.15）
* 配置python的环境变量
* 配置python目录下（默认目录的话应该在C:\Python27）Scripts/pip的环境变量
* 安装protobuf （pip install google  和   pip install protobuf ）
* 安装xlrd（pip install xlrd）
* mac环境下 brew install protobuf

### 使用事项
* excel 的前四行用于结构定义, 其余则为数据
    - 第一行：protobuf关键字（required: 必有属性，optional：可选属性，repeated：重复属性等）
    - 第二行：字段的数据类型
    - 第三行：字段名
    - 第四行：注释