const btnLoadPostEl = document.getElementById('btnLoadPosts');
const selectEl = document.getElementById('posts');
const btnViewPostEl = document.getElementById('btnViewPost');
const postTitleEl = document.getElementById('post-title');
const postBodyEl = document.getElementById('post-body');
const postCommentsEl = document.getElementById('post-comments');




function attachEvents() {
    btnLoadPostEl.addEventListener('click', loadAllPosts);
    btnViewPostEl.addEventListener('click', viewSelectedPost);
}

async function loadAllPosts(e) {
    const postsRes = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsData = await postsRes.json();
    // console.log(postData);
    const objArrPostData = Object.values(postsData);
    // console.log(objArrPostData);
    
    for (const post of objArrPostData) {
        const optionEl = document.createElement('option');
        optionEl.value = post.id;
        optionEl.textContent = post.title;
        selectEl.appendChild(optionEl);            
    }
    
}
async function viewSelectedPost(e) {
    const commentsRes = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const commentsData = await commentsRes.json();
    // console.log(commentsData);
    const objArrCommentsData = Object.values(commentsData);

    const postsRes = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const postsData = await postsRes.json();
    // console.log(postData);
    const objArrPostData = Object.values(postsData);


    // console.log(objArrCommentsData);
    
    const currentPostId = selectEl.value;
    const currentPost = objArrPostData.find(post => post.id === currentPostId);
    // console.log(postContent);
    postBodyEl.textContent = currentPost.body;
    postTitleEl.textContent = currentPost.title;

    postCommentsEl.innerHTML = '';

    for (const comment of objArrCommentsData.filter(comment => comment.postId === currentPostId)) {
        const newLiEl = document.createElement('li');
        newLiEl.textContent = comment.text;
        postCommentsEl.appendChild(newLiEl);
    }
    
}

attachEvents();