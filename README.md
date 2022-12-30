# CharacterApi - Documentação em Português
  Batalha entre personagens 

## Descrição 
  Esse projeto consiste em uma api que gerencia o cadastro e batalhas entre personagens.

### Features

- [x] Cadastro de personagens
- [x] Remover personagen
- [x] Lista de personsagens 
- [ ] Paginação da lista de personagens
- [x] Detalhe do personsagem 
- [x] Batalha entre personsagens

## Endpoints 
Segue a lista de endpoints construido nessa api para gerenciar os cadastros e a batalha entre os personagens.

## Post /Character
   Endpoint responsável pelo cadastro do personagem.

### Paramaters
    - Name
      O nome deve ter no máximo 15 caracteres, não pode conter números, não pode conter simbolos com excessão do "_" subscribe.
    - Profession
      São 3 tipos de personagens disponiveis 
      1 - Warrior 
      2 - Thief 
      3 - Mage 

### Response 
    
    {
      "data": { 
                "strength": 0,
                "dexterity": 0,
                "intelligence": 0,
                "name": "string",
                "hitPoints": 0,
                "profession": "Warrior",
                "status": "Alive",
                "attackAttributes": {
                                      "strength": 0,
                                      "dexterity": 0,
                                      "intelligence": 0
                                     },
                "speedAttributes": {
                                      "strength": 0,
                                      "dexterity": 0,
                                      "intelligence": 0
                                   }
                  },
          "status": "Error",
          "message": "string",
          "notification": [{
                              "exception": "string",
                              "message": "string"
                            }
                           ]
         }

## Delete /Character
   Endpoint responsável pela remoção do personagem.
   
### Paramaters
    - Name
      O personagem será validado se existe no cache.

### Response
      {
        "data": "string",
        "status": "Error",
        "message": "string",
        "notification": [
         {
            "exception": "string",
            "message": "string"
         }
        ]
       }

## Get /Character
   Endpoint responsável por retornar a lista de personagens cadastrado.
### Paramaters

## Get /Character/Details
   Endpoint responsável por retornar os detalhes do personagem.
### Paramaters

## Post /Battle
   Endpoint responsável por gerar a batalha entre os personsagens.
### Paramaters

# CharacterApi
  Battle Between characters   

## Description
  This project is a api was built for managament register and batlles beteen characters


### Features

- [x] Register character
- [x] Delete character
- [x] List of characters 
- [x] Details of character 
- [x] Batller bettween character
