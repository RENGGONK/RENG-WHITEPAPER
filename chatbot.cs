// chatbot.js
(function() {
  const style = document.createElement('style');
  style.textContent = `
    #chat-icon {
      position: fixed;
      bottom: 20px;
      right: 20px;
      width: 60px;
      height: 60px;
      background: url('https://em-content.zobj.net/thumbs/240/google/350/frog_1f438.png') no-repeat center center / cover;
      border-radius: 50%;
      cursor: pointer;
      z-index: 9999;
    }
    #chat-box {
      display: none;
      position: fixed;
      bottom: 90px;
      right: 20px;
      width: 300px;
      max-height: 400px;
      background: white;
      border: 2px solid #ddd;
      border-radius: 10px;
      box-shadow: 0 0 10px rgba(0,0,0,0.3);
      z-index: 10000;
      display: flex;
      flex-direction: column;
      font-family: sans-serif;
    }
    #chat-messages {
      flex: 1;
      padding: 10px;
      overflow-y: auto;
      font-size: 14px;
    }
    #chat-input {
      display: flex;
      border-top: 1px solid #ddd;
    }
    #chat-input input {
      flex: 1;
      padding: 8px;
      border: none;
      outline: none;
    }
    #chat-input button {
      background: #5ecd5e;
      border: none;
      padding: 8px 12px;
      cursor: pointer;
      color: white;
    }
  `;
  document.head.appendChild(style);

  const icon = document.createElement('div');
  icon.id = 'chat-icon';
  icon.onclick = () => {
    box.style.display = box.style.display === 'none' ? 'flex' : 'none';
  };
  document.body.appendChild(icon);

  const box = document.createElement('div');
  box.id = 'chat-box';
  box.innerHTML = `
    <div id="chat-messages"></div>
    <div id="chat-input">
      <input type="text" id="chat-text" placeholder="Tanya RENGGONK..." />
      <button onclick="sendChat()">Kirim</button>
    </div>
  `;
  document.body.appendChild(box);

  window.sendChat = async function () {
    const input = document.getElementById('chat-text');
    const msg = input.value.trim();
    if (!msg) return;

    const messages = document.getElementById('chat-messages');
    messages.innerHTML += `<div><b>🧑 Kamu:</b> ${msg}</div>`;
    input.value = '';
    messages.scrollTop = messages.scrollHeight;

    try {
      const res = await fetch('https://c517d1dd-31b9-4c12-85ea-ca8b25d2da44-00-3g1w8j8323v4c.pike.replit.dev/chat', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ message: msg })
      });
      const data = await res.json();
      messages.innerHTML += `<div><b>🐸 RENGGONK:</b> ${data.reply}</div>`;
    } catch (e) {
      messages.innerHTML += `<div><b>🐸 RENGGONK:</b> Gagal koneksi ke server!</div>`;
    }
    messages.scrollTop = messages.scrollHeight;
  };
})();
