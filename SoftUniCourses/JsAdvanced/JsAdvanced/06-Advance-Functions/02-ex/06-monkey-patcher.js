let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']

for (let index = 0; index < 50; index++) {
    solution.call(post, 'downvote');
}// (executed 50 times)
score = solution.call(post, 'score');

var forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 0
};

solution.call(forumPost, 'upvote');
console.log(solution.call(forumPost, 'score'));


function solution(arg) {

    if (arg == 'upvote') {
        this.upvotes += 1;
    } else if (arg == 'downvote') {
        this.downvotes += 1;
    } else if (arg == 'score') {
        let totalScore = getTotalScore(this);
        return getObfuscated(this, totalScore);
    }

    function getObfuscated(obj, totalScore) {
        let upvotes = obj.upvotes;
        let downvotes = obj.downvotes;

        let balance = upvotes - downvotes;
        let obfuscatedNumber = 0;
        let rate = getRate(upvotes, downvotes);

        if (totalScore > 50) {

            if (balance > 0) {
                obfuscatedNumber = Math.ceil(upvotes * 0.25);

            } else {
                obfuscatedNumber = Math.ceil(downvotes * 0.25);
            }
            upvotes += obfuscatedNumber;
            downvotes += obfuscatedNumber;
        }
        let rating = getRating(balance, rate, totalScore);

        return [upvotes, downvotes, balance, rating];
    }



    function getRate(upvote, downvote) {
        return (upvote / downvote) * 100;
    }

    function getRating(balance, rate, totalScore) {

        if (balance > 0 && rate > 66 && totalScore >= 10) {
            return 'hot'
        } else if (balance == 0 && totalScore >= 10) {
            return 'controversial';
        } else if (balance < 0) {
            return 'unpopular'
        } else {
            return 'new'
        }



        // if (totalScore < 10 || rate <= 66) {
        //     return 'new'
        // }
        // if (balance == 0) {
        //     return 'controversial';
        // } else if (balance > 0 && rate > 66) {
        //     return 'hot';
        // } else {
        //     return 'unpopular';
        // }
    }

    function getTotalScore(obj) {
        return obj.upvotes + obj.downvotes;
    }

}

