match (n) detach delete n;


CREATE (cool:Group {uuid: "3ba1c567-8775-4dce-9b31-0c1a66a158b0", name: "Groupe cool"});

CREATE (leBavard:Restaurant {uuid: "15729bba-a20f-4596-850b-3a516002ead1", name: "Le Bavard", takeout: false});
CREATE (les5sens:Restaurant {uuid: "d962ec9d-e023-44d5-8562-ddf14418b20d", name: "Les 5 Sens", takeout: false});
CREATE (levintage:Restaurant {uuid: "f63f643f-7ee7-494a-a246-fb6c60e3d3e6", name: "Le Vintage", takeout: false});
CREATE (lacourdhonneur:Restaurant {uuid: "2843a091-3c6f-4963-a696-6ec4f328d75c", name: "La cour d'Honneur", takeout: false});

CREATE (didier:Person {uuid: "97f660b7-15e0-4a5f-8b58-1da6403d1cfd", name: "Didier"});
CREATE (ludovic:Person {uuid: "56927cb0-dc08-4f4a-ad43-38e4d21d2b55", name: "Ludo"});

CREATE (didier)-[:MEMBER_OF]->(cool);
CREATE (ludovic)-[:MEMBER_OF]->(cool);

CREATE (leBavard)-[:BELONGS_TO]->(cool);
CREATE (les5sens)-[:BELONGS_TO]->(cool);
CREATE (levintage)-[:BELONGS_TO]->(cool);
CREATE (lacourdhonneur)-[:BELONGS_TO]->(cool);

CREATE (didier)-[:PLANNED {date: "02052017"}]->(vote:Event {uuid: "cb0eff3c-3137-4654-8c0e-5a70ac7ce113"})-[:BELONGS_TO]->(cool);
CREATE (didier)-[:POLL]->(cDidier:Choice {uuid: "ca52e97c-28bb-4c08-98e8-8c6ff3da2239"})-[:PART_OF]->(vote);

CREATE (ludovic)-[:POLL]->(cLudo:Choice {uuid: "262a6f2b-3af2-494f-8cab-52281519c807"})-[:PART_OF]->(vote);

CREATE (leBavard)-[:SELECTED]->(cDidier);
CREATE (leBavard)-[:SELECTED]->(cLudo);
CREATE (levintage)-[:SELECTED]->(cDidier);
CREATE (lacourdhonneur)-[:SELECTED]->(cLudo);

create constraint on (r:Restaurant) assert r.uuid is unique;
create constraint on (p:Person) assert p.uuid is unique;
create constraint on (g:Group) assert g.uuid is unique;  
