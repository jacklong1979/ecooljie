db.getCollection('GoodsType').find({})


db.getCollection('GoodsType').find({}).Where(Code == "CC").Skip(PageIndex * PageSize).Take(PageSize).ToList()

db.getCollection('GoodsType').find({"$query" : {"Code": "CC"}}).skip(0).limit(3)
show tables

