# Web 发布手册

## 服务器信息

| 项目 | 值 |
|------|-----|
| 公网 IP | `124.220.6.174` |
| SSH 用户 | `ubuntu` |
| 证书路径 | `/Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem` |
| Web 根目录 | `/var/www/nginx_124.220.6.174/` |

## 目录结构

```
本地 benchmarks/web/                    服务器 /var/www/nginx_124.220.6.174/
├── homepage/
│   └── index.html          →           index.html          (首页)
├── index.html              →           benchmark/index.html (性能报告子页面)
└── data.json               →           benchmark/data.json  (报告数据)
```

访问地址：
- 首页：`http://124.220.6.174/`
- 性能报告：`http://124.220.6.174/benchmark/`

---

## 快速发布命令

### 一键全量发布（首页 + 性能报告）

```bash
# 定义变量
SSH_KEY="/Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem"
SERVER="ubuntu@124.220.6.174"
WEB_ROOT="/var/www/nginx_124.220.6.174"
LOCAL_WEB="/Users/boom/Demo/Unity-Benchmark-Test/benchmarks/web"

# 上传首页
scp -i $SSH_KEY $LOCAL_WEB/homepage/index.html $SERVER:$WEB_ROOT/index.html

# 上传性能报告（先确保目录存在）
ssh -i $SSH_KEY $SERVER "mkdir -p $WEB_ROOT/benchmark"
scp -i $SSH_KEY $LOCAL_WEB/index.html $LOCAL_WEB/data.json $SERVER:$WEB_ROOT/benchmark/
```

### 只更新性能报告数据

每次跑完 BenchmarkDotNet、重新生成 `data.json` 后执行：

```bash
SSH_KEY="/Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem"
SERVER="ubuntu@124.220.6.174"

scp -i $SSH_KEY \
  /Users/boom/Demo/Unity-Benchmark-Test/benchmarks/web/index.html \
  /Users/boom/Demo/Unity-Benchmark-Test/benchmarks/web/data.json \
  ubuntu@124.220.6.174:/var/www/nginx_124.220.6.174/benchmark/
```

### 只更新首页

```bash
scp -i /Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem \
  /Users/boom/Demo/Unity-Benchmark-Test/benchmarks/web/homepage/index.html \
  ubuntu@124.220.6.174:/var/www/nginx_124.220.6.174/index.html
```

---

## 添加新子页面

例如新增 `/jobs/` 专题页面：

1. 本地创建 `benchmarks/web/jobs/index.html`
2. 上传到服务器：
   ```bash
   SSH_KEY="/Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem"
   ssh -i $SSH_KEY ubuntu@124.220.6.174 "mkdir -p /var/www/nginx_124.220.6.174/jobs"
   scp -i $SSH_KEY \
     /Users/boom/Demo/Unity-Benchmark-Test/benchmarks/web/jobs/index.html \
     ubuntu@124.220.6.174:/var/www/nginx_124.220.6.174/jobs/
   ```
3. 在 `homepage/index.html` 的导航栏和卡片区加入入口链接
4. 重新发布首页

---

## Nginx 配置说明

Nginx 配置文件在 `/etc/nginx/sites-available/default`，已启用（`sites-enabled/default` 软链接）。
静态文件由 `try_files $uri $uri/ =404` 自动处理，**新增子目录无需改 Nginx 配置**。

验证 Nginx 状态：

```bash
ssh -i /Users/boom/Demo/Avalon/go_svr/sshkey/wepie_mac.pem ubuntu@124.220.6.174 \
  "sudo nginx -t && sudo systemctl status nginx --no-pager -l"
```

---

## 发布验证

```bash
# 检查首页
curl -s -o /dev/null -w "%{http_code}" http://124.220.6.174/

# 检查性能报告
curl -s -o /dev/null -w "%{http_code}" http://124.220.6.174/benchmark/
```

两者均返回 `200` 表示发布成功。
