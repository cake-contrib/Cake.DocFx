
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"DocFxSettings",
        content:"DocFxSettings",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"DocFxInitSettings",
        content:"DocFxInitSettings",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"DocFxBuildSettings",
        content:"DocFxBuildSettings",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"DocFxMetadataAliases",
        content:"DocFxMetadataAliases",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"DocFxAliases",
        content:"DocFxAliases",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"DocFxMetadataSettings",
        content:"DocFxMetadataSettings",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"DocFxGlobalMetadata",
        content:"DocFxGlobalMetadata",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"DocFxBuildAliases",
        content:"DocFxBuildAliases",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"DocFxInitAliases",
        content:"DocFxInitAliases",
        description:'',
        tags:''
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxSettings',
        title:"DocFxSettings",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx.Init/DocFxInitSettings',
        title:"DocFxInitSettings",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx.Build/DocFxBuildSettings',
        title:"DocFxBuildSettings",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxMetadataAliases',
        title:"DocFxMetadataAliases",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxAliases',
        title:"DocFxAliases",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx.Metadata/DocFxMetadataSettings',
        title:"DocFxMetadataSettings",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxGlobalMetadata',
        title:"DocFxGlobalMetadata",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxBuildAliases',
        title:"DocFxBuildAliases",
        description:""
    });

    y({
        url:'/Cake.DocFx/Cake.DocFx/api/Cake.DocFx/DocFxInitAliases',
        title:"DocFxInitAliases",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
