
export class Recipe {
  constructor(data) {
    this.id = data.id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.title = data.title
    this.category = data.category
    this.instructions = data.instructions
    this.img = data.img
    this.creatorId = data.creatorId
    this.creator = data.creator

  }
}


// {
//   "id": 1,
//     "createdAt": "2023-08-18T02:57:59",
//       "updatedAt": "2023-08-18T02:57:59",
//         "title": "french toast",
//           "category": "breakfast",
//             "instructions": "Dip in egg, cin and milk then fry",
//               "img": "https://images.unsplash.com/photo-1595044643502-616eeebbdff3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1740&q=80",
//                 "creatorId": "64c49aff4205aa3b679342ad",
//                   "creator": {
//     "id": "64c49aff4205aa3b679342ad",
//       "createdAt": "2023-08-17T17:38:23",
//         "updatedAt": "2023-08-17T17:38:23",
//           "name": "dewdrop@mykitty.com",
//             "picture": "https://s.gravatar.com/avatar/0a997d4cad3ac1458af27ba01e3f8b03?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fde.png"
//   }
// }