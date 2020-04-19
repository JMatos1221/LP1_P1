# Wolf and Sheep

André Figueira a21901435  
João Matos a21901219  
 Miguel Feliciano a21904115  

---

## Commits e Trabalho Realizado

1. **First Commit** - João Matos  
   Criação do projeto.
2. **Starting board design** - João Matos  
   Design base do jogo, criação do tabuleiro de jogo.
3. **First gameplay created** - André Figueira
   Implementação do movimento dos jogadores.
4. **functional game** - Miguel Feliciano
   Implementação das regras de jogo, prevenção de alguns erros de Input e range de arrays.
5. **Bugfixing and polishing** - João Matos  
   Correção de bugs de Input e polishing do visual do jogo.
6. **Commenting and report added, changed functions to uppercase** - André Figueira
   Comentação do código e relátorio adicionados. Funções com iniciais maiúsculas.

Apesar da divisão dos commits do trabalho pelo grupo, o trabalho foi realizado por todos os membros do grupo através de sessões de `Live Share` e partilha de ecrã através da aplicação `Discord`, assim todo o trabalho foi realizado em conjunto, de modo a facilitar a realização do mesmo.

## [Repositório Github](https://github.com/JMatos1221/LP1_P1)

## Arquitetura da Solução

Como solução para este trabalho, pensámos em dividir o jogo por "etapas", ou seja, os vários procedimentos que o jogo iria ter. Foram criados vários métodos de forma a criar um `game loop`. 

Primeiro, decidimos desenhar o tabuleiro de jogo, tendo decidido que seria melhor e mais simples como comandos de jogo ter um sistema de coordenadas, algo parecido à batalha naval, sendo de `1` a `8` para as colunas e de `A` a `H` para as filas.

Desenhamos então o tabuleiro do jogo com um array bidimensional, 8x8, 8 filas e 8 colunas, sendo depois colocadas as ovelhas nas suas devidas posições. Feito isto, procedemos a pedir ao jogador, qual a posição onde queria colocar o Lobo.

Feitas estas "etapas" chegamos ao ponto do `game loop` onde o jogo entra num ciclo `do while` com a condição da variável `gameOver` ser `false`, sendo que este `game loop` consiste nos movimentos dos jogadores e na verificação do fim do jogo. 

## Métodos e enumerações

- `enum` playerName - Enumeração consistente por dois valores, `Wolf (1)` e `Sheep (2)`, utilizada para gerir os turnos dos jogadores e representação do nome do jogador (Wolf ou Sheep) cada vez que o tabuleiro de jogo for imprimido, dando assim um melhor feedback.

- `private static void` print_instructions() - Método criado para imprimir as instruções no início do jogo e sempre que o jogador chamar o comando `help`.

- `private static void` print_game(`int`[,] table, `playerName` player_name) - Método utilizado para imprimir o tabuleiro do jogo e a quem pertence o turno. Este é um método implementado com overload, sendo que nem sempre recebe a variável `playerName` player, para se poder imprimir o tabuleiro sem imprimir a quem pertence o turno, como no início e fim do jogo.

- `private static void` game_check(`int`[,] table, `int`[] wolf) - Método que verifica se o Lobo chegou ao fundo do tabuleiro (fila 8), atribuindo-lhe assim a vitória, ou se o Lobo tem jogadas possíveis, sendo que se não tiver, atribui-se a vitória às Ovelhas.
  
## Fluxograma  

![Fluxograma](fluxograma.png)