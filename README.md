# Prototype_Task_2_Game_Design
 
## Intent:

When playing a few cooperative multiplayer games, I found one mechanic that I found very
intriguing. The mechanic consisted of two characters being tied together by a rope of sort and
having to work together to achieve a certain goal, because they are tied together.

Why did I find this mechanic to be so intriguing:
- This is different to many multiplayer games I have played before, where you play
together, but you do your own thing.
- This forces players to collaborate in their solutions to puzzles.
- I have made many playable characters that walk on their own, I have never made two
playable characters that have to be attached to each other.

Because I find this mechanic to be so interesting, I would like to try and replicate it in Unity.

What would I like to achieve by replicating this mechanic:
- Have a Player Controller that can be used in local multiplayer games.
- Find out how to tie two characters together and make this aspect work with movement
and jumping.
- Figure out how to make it look like the two players are connected to each other.
- Explore different ways this mechanic can be used.

## Process:

- The first thing I did before starting my prototype is playing games.
- I was unsure about what I wanted to do for this prototype. I was really struggling with the
prompt, and it took me a while to find something I wanted to do. I was really feeling the
creative block on this one.
- The three games I played:
   - Bread & Fred (Demo) (2023): A game where two penguins are attached by a rope, and
the players must work together to reach the top of the mountain. They can achieve this
by jumping together, pulling each other, or swinging and flinging themselves onto
platforms.
   - Pikwip (2022): In this game the two players are attached to each other by a stretchy
rope that enables the players to pull each other to wherever they are going.
   - Pico Park (2021): This is a game where 2-8 players must work together to finish levels.
In some of the levels, the players are tied together.
- The one mechanic that was present in all three of these games that I found the most
intriguing is where the two players are attached to each other.
- I especially enjoyed how the mechanic was implemented in Bread & Fred (2023).
- In approaching the replication of this mechanic, I separated the mechanic into different
parts. I approached all these step by step, to then achieve the mechanic in my own
prototype:
   - I first created two playable characters and made them move and jump.
      - This was easy enough, and something I have done on multiple occasions for single
player games, I just copied the code for player 2 and bound the movements to
different keys.
   - Then I thought about the different things I want the players to be able to do when
attached to each other:
      - I want the two players to be able to drag each other when only one of the players
are moving

![Image](/Assets/Art/ropeTied/RopeTied1.png)

      - The two players will always be a certain distance from each other, no matter where
and how the players move or jump, some of these movements might just be slightly
hindered, because the players are tied together.

![Image](/Assets/Art/ropeTied/RopeTied2.png)

      - When jumping separately, the jumping player should pull the stationary player.

![Image](/Assets/Art/ropeTied/RopeTied3.png)

      - When players jump together however, they should be able to move farther, and
more easily, making the jumping movement less hindered.

![Image](/Assets/Art/ropeTied/RopeTied4.png)

      - Players should be able to grab onto platforms and walls, and then be able to swing if
there are no obstacles in the way.

![Image](/Assets/Art/ropeTied/RopeTied5.png)

      - Maybe the players would be able to fling themselves in a direction using the
momentum of the swinging.

![Image](/Assets/Art/ropeTied/RopeTied6.png)

      - The players will then be working together to achieve a goal. For this prototype, I
thought that having a button they need to press would be the best.

![Image](/Assets/Art/ropeTied/RopeTied7.png)

- After analysing the different aspects of this mechanic and which ones I would like to use
in my prototype, I started with trying to get the players tied together.

- This was a feat. I started by trying to just keep a certain distance between the characters
through code. The problems with this:
   - When player one moves left or right, it drags player two behind them.
   - However, the same does not happen when player two moves left or right. With player
two, it’s like player one is stuck to the floor.
   - The above was achieved by only limiting the x-axis, which becomes a problem when
jumping, because the y-axis is not limited.

- To combat the problem with the jumping distance also being limited, I thought that
maybe I should “draw” a circle around the objects and make sure the players stay in these
distances. The problems with this:
   - Very similar issues to above, with one player pulling the other but not vice versa.
   - It also seemed as if this “circle” was limiting the momentum the players have when
jumping in any direction.

- I then remembered one of my peers mentioning that they were using a hinge joint in one
of their games. I then tried to implement this as a rope between my two players. The
problems with this:
   - The hinge joints would not connect to the players. No matter what I did, it just fell
limp on the floor, or exploded into the different hinge parts that flung all over the
screen. This is obviously not what I wanted.

- Then I discovered the world of joints. This is something I have never heard of before and
had never explored before. I came upon my saviour, the Spring Joint. I implemented this
joint between the players, and it was almost perfect. The problems:
   - When the players reached a certain distance apart, they shoot back together… like a
spring.

- Because this was the closest to what I needed, I was determined to make it work. At this
point, it was doing most of what I wanted it to do:
   - When a player moves and the other stands still, they drag the stationary one behind
them.
   - When a player jumps and the other is stationary, the jumping player pulls the
stationary player up.
   - When the players jumped together, they could jump higher and farther.

- So, to solve the spring problem, I just disabled the Spring Joint when the players got
within a certain distance of each other and enabled it again when they exited this range.
- I also fiddled with the components within the Spring Joint to make the bounciness less,
and this made for quite a decent rope (Shown in Balancing below).

- I then moved on to the grabbing aspect of the mechanic. To achieve this effect, I used the
colliders on the walls, platforms, and the players.
- When the players touch the wall or platform and they press the grab button, this freezes
the position of the player, causing a ‘grabbing’ effect.
- From this, a different mechanic emerged. While the player is grabbing onto the platform,
they can move around in and on it.
- I though about removing this part or adjusting the code so that this was not possible, but
while playtesting, I saw that this was a part that the players used to their advantage (and
sometimes to their detriment), but it did not take away from the mechanic itself. So, I
decided to leave it as is.

- When thinking about how I would apply the swinging part of the mechanic, I found that
the players were already swinging. I suspect that the movement as well as the Rigid
Bodies were causing the swinging effect.
- It was not as smooth as I would have liked it to be, but it worked, so I left it.
- In playtesting, however, one of the play testers showed me what the AddForce function is
and how it worked. I applied this to the movement of the players when they were in the
air, and I got a smoother swinging effect, something a lot closer to what I was
envisioning.

- After getting the mechanic where I wanted it to be, I started thinking about how I could
play with the character shapes. How would this mechanic work if the characters were
round? Or Triangular?

![Image](/Assets/Art/ropeTied/RopeTied8.png)

- I tried this by changing the shape of the sprite and the collider.
- This did not make it to play testing, however, as it utterly sucked. There is no better way
of describing it.
   - The circles rolled around and messed with the movement physics making the players
move really slow, because they are constantly being pulled in the opposite direction.
Not even moving both players in the same direction helped with this.
      - Jumping co-operatively was impossible, as with some of the jumps the players need
to be on top of each other.
   - The triangles would not work with me when it came to the colliders, and the same
issue as above with jumping was applicable here.
- I made the decision that square players would be best for the prototype I am trying to
achieve.

## Balancing:

There was not too much to balance in this prototype, mostly just adjusting the positions of
platforms in a level. That, however, was more of a ‘does this feel right’ situation, and less of a
balancing numbers situation. There was some balancing to do though.

*Key:*

- **Distance:** The distance that the Spring Joint aims to keep between the two players.
- **Frequency:** How often the spring oscillates to keep the distance between the players
where it needs to be. The higher this is, the less visible this bounce is.
- **Speed:** The speed of the player movement.
- **Jump:** The velocity of the player jump.

| Iteration 1: Spring Joint |
| ----------- |
| Distance | 2 |
| Frequency | 1 |

This was the default for this unity
component. The joint was too
bouncy, and it would keep bouncing
every few seconds as it tried to keep
the distance consistent.

| Iteration 2: Spring Joint |
| ----------- |
| Distance | 2 |
| Frequency | 8 |

The frequency of the bouncing has
been increased, so it is not visible
anymore, it only looks like the
players are dragging each other now.
The distance is too short still.

| Iteration 3: Spring Joint |
| ----------- |
| Distance | 3 |
| Frequency | 8 |

These are perfect, the distance works
for the puzzles that I made, as well
as the goals I had for the mechanic.

| Iteration 1: Player Movement |
| ----------- |
| Speed | 2 |
| Jump | 2 |

The speed in this version is perfect. I
do not feel as if they need to move
too fast. The jump is too short, it
does not give the jumpy feeling I
want it to have.

| Iteration 2: Player Movement |
| ----------- |
| Speed | 2 |
| Jump | 2 |

The jump is better, but not there yet,
it still is not high enough.

| Iteration 3: Player Movement |
| ----------- |
| Speed | 2 |
| Jump | 2 |

The jump and the speed are where I
want it to be for this prototype.

## Playtests:

The playtests happened with two external players for each test. The answers the testers in
each game gave were very similar to each other, so I combined them into one answer.

**Play 1:**

*Is there any part of the mechanic that feels weird or wrong, what and why?*

The swinging is very difficult to figure out. The momentum is easy to lose. Maybe give a hint
on how to do the swinging right? The bounce to the rope does feel a bit odd, as this also
messes with the momentum in the swinging part of the mechanic. The blocks do not feel like
they have enough weight, this might be because they spin.

*If you have played Bread & Fred (2023), how does it feel different from the mechanic in that game?*

It felt like the characters had Spider Man attributes, as it felt like the characters are almost
skittering. The stretch in the rope is nice and makes for a nice difference. The rope bounces in
this, where it does not in Bread & Fred (2023).

*Do you think these differences takes away or adds to the mechanic?*

The bounce feels wrong, and makes it hard to play, especially when swinging.

*Is there anything you would have done differently?*

The grabbing key bind is in a weird position. It might be better to have player one’s grab
button be E, and Player two’s Page Down.

**Play 2:**

*Is there any part of the mechanic that feels weird or wrong, what and why?*
The swinging is very hard to control, even when you know how to get the rhythm that makes
it work. 

*If you have played Bread & Fred (2023), how does it feel different from the mechanic in that game?*

The momentum carries through the swing less in this prototype than it does in the game,
which also makes the swing harder to control. However, the fact that the characters can move
through the platforms is cool and makes for an interesting thing to experiment with.

*Do you think these differences takes away or adds to the mechanic?*

The fact that the characters can move through the platforms adds to the mechanic. It enables
the players to find different anchor points to have different outcomes to the swing.

*Is there anything you would have done differently?*

Instead of just using the movement and the rigid body for the swing, why not use AddForce?

**Play 3:**

*Is there any part of the mechanic that feels weird or wrong, what and why?*

The spinning of the characters felt odd. It felt like the players would get in their own way
when they swing and accidentally hit a platform. The spinning was also visually confusing, in
trying to combat the spinning, the moving direction would change suddenly, and the
momentum would be gone.

These players wanted top walk on the roof, but that was not available.

*If you have played Bread & Fred (2023), how does it feel different from the mechanic in that game?*

It feels very similar. The rope is more spring like. The physics does not feel the same, the
flinging part that players can do in Bread & Fred does not seem possible with the physics in
this prototype.

*Do you think these differences takes away or adds to the mechanic?*

The flinging was not necessary, so the fact that the flinging was not as usable in this
prototype, did not take away from the mechanic.

*Is there anything you would have done differently?*

Nothing really, besides taking out the springy-ness in the rope.

After these playtests, the tester who suggested using AddForce showed me how this function
works. I added it to the swinging aspect of the mechanic by detecting when the player was off
the floor, which then enables them to swing. This made for a smoother, more controllable
swinging.

## Reflection:

In replicating this mechanic, I learned so many things. I learned things about Unity, as well as
about how to use certain functions in C#. I will be explaining what I learned through
evaluating whether I reached my goals for this prototype.

**Have a player controller that can be used in local multiplayer games.**

I now have a reusable Player Controller. This is something I will be able to use again, as well
as add to if there are any other actions that I would like my players to be able to do. I will be
able to use this Player Controller not only for local multiplayer games, but also for single
player games if I just comment out the second player’s code. I had coded the two players’
separately, so this would not be a problem.

**Find out how to tie two characters together and make this aspect work with movement and jumping.**

This was quite the exploration while trying to figure out how to do this. The main thing I
learned about here was joints. I had never used them before, and when starting this
exploration, I only knew about the Hinge Joint. In excessive Googling, I found out about the
world of joints. There are so many types, and I tested all of them.

From Distance Joints to Fixed Joints to Relative Joints. I finally settled on a Spring Joint.
This joint keeps the two objects a certain distance from each other, and when they exit this
distance, they bounce back like a spring. With a little bit of code and some adjustments to the
component, I was able to make a convincing rope, that only bounces a little bit.

With the Spring Joint, the players can drag each other when moving, as well as when
jumping.

**Figure out how to make it look like the two players are connected to each other.**

This was another aspect that took me a while to figure out, but then I found line renderers.
This is also something I have never used before. I also had never heard of it before. This gave
me a simple way to illustrate that the two players are connected by a rope, without having to
mess with hinge joints that just gave me a lot of trouble.

It is not a dynamic, moving rope, but it does get the message across.

**Explore different ways this mechanic can be used.**

I did not make any drastic discoveries here; however, I did accidentally implement a crawling
aspect to the mechanic.

When the players are grabbing onto a platform within the play area, they can move along this
platform by moving left or right. At first, I wanted to remove this, but I decided to leave it to
see what players would do with it.

Players used this to their advantage, but also their detriment. It made new anchor points to
swing from, but it also complicated grabbing onto another platform.

I found in playtesting that players seemed to enjoy this and feels like it adds to the mechanic.

**Anything else that I learned:**

I learned about the AddForce function in C#. I knew about this, but I was not sure how it
worked, and since my swinging was working (albeit a bit janky), I did not know if it was
necessary. However, one of the play testers \showed me how it works, and how simple it
actually is. I added it to my code, and it did wonders for the swinging aspect of the mechanic.
I am eternally grateful to them for showing me how it works, as I now have another thing in
my arsenal, and a better working mechanic and Player Controller.

In conclusion, this prototype was a lot more valuable than I originally thought it would be. I
was not sure if replicating a mechanic that I liked would be the best approach for me, but I
was wrong. I learned so much through replicating this mechanic, and the things I learned are
things I will use in the future, and I am sure they will make my future endeavours a little
easier, even if it is by a minute amount. Every little bit counts. In the end I found a large
amount of value in doing this, and I will probably do something like this (replicating
mechanics I like) in the future.

## References:

Bread & Fred Demo. (2023) PC [Game]. Apogee Entertainment. [Available at:
https://store.steampowered.com/app/1607680/Bread__Fred/]

Pico Park. (2021) PC [Game]. TECOPARK. [Available at:
https://store.steampowered.com/app/1509960/PICO_PARK/]

Pikwip. (2022) PC [Game]. cookiecrayon. [Available at: https://cookiecrayon.itch.io/pikwip]