
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"DocFxInitSettings",
            content:"DocFxInitSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Init/DocFxInitSettings',
            title:"DocFxInitSettings",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"DocFxServeSettings",
            content:"DocFxServeSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Serve/DocFxServeSettings',
            title:"DocFxServeSettings",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"DocFxPdfAliases",
            content:"DocFxPdfAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxPdfAliases',
            title:"DocFxPdfAliases",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"DocFxBuildAliases",
            content:"DocFxBuildAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxBuildAliases',
            title:"DocFxBuildAliases",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"DocFxMergeSettings",
            content:"DocFxMergeSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Merge/DocFxMergeSettings',
            title:"DocFxMergeSettings",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"DocFxAliases",
            content:"DocFxAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxAliases',
            title:"DocFxAliases",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"BaseDocFxLogSettings",
            content:"BaseDocFxLogSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/BaseDocFxLogSettings',
            title:"BaseDocFxLogSettings",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"DocFxServeAliases",
            content:"DocFxServeAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxServeAliases',
            title:"DocFxServeAliases",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"DocFxMetadataSettings",
            content:"DocFxMetadataSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Metadata/DocFxMetadataSettings',
            title:"DocFxMetadataSettings",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"DocFxSettings",
            content:"DocFxSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxSettings',
            title:"DocFxSettings",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"DocFxMergeAliases",
            content:"DocFxMergeAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxMergeAliases',
            title:"DocFxMergeAliases",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"DocFxPdfSettings",
            content:"DocFxPdfSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Pdf/DocFxPdfSettings',
            title:"DocFxPdfSettings",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"DocFxLogLevel",
            content:"DocFxLogLevel",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxLogLevel',
            title:"DocFxLogLevel",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"DocFxBuildSettings",
            content:"DocFxBuildSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx.Build/DocFxBuildSettings',
            title:"DocFxBuildSettings",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"DocFxGlobalMetadata",
            content:"DocFxGlobalMetadata",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxGlobalMetadata',
            title:"DocFxGlobalMetadata",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"DocFxMetadataAliases",
            content:"DocFxMetadataAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxMetadataAliases',
            title:"DocFxMetadataAliases",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"DocFxInitAliases",
            content:"DocFxInitAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.DocFx/api/Cake.DocFx/DocFxInitAliases',
            title:"DocFxInitAliases",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
